using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MusicList : MonoBehaviour
{
    public static List<AudioClip> Musics;
    private static string MusicsPath = "E:/Music";

    [SerializeField] private Transform listViewParent;
    [SerializeField] private GameObject musicListObject;
    
    private void Start()
    {
        Musics = new List<AudioClip>();
        PopulateListView();
    }

    private void PopulateListView()
    {
        if (Directory.Exists(MusicsPath))
        {
            int i = 0;
            foreach (var file in Directory.GetFiles(MusicsPath))
            {
                if (IsMusicFile(file))
                {
                    StartCoroutine(AddToMusicList(file));
                    CreatListItem(Path.GetFileName(file), i);
                }

                i++;
            }
        }
    }

    private IEnumerator AddToMusicList(string file)
    {
        WWW www = new WWW(file);
        yield return www;

        AudioClip clip = www.GetAudioClip(false, false);
        Musics.Add(clip);
    }

    private void CreatListItem(string fileName, int index)
    {
        GameObject newListItem = Instantiate(musicListObject, listViewParent);

        TextMeshProUGUI textMesh = newListItem.GetComponentInChildren<TextMeshProUGUI>();
        if (textMesh != null)
        {
            fileName = fileName.Substring(0, fileName.Length - 4);
            textMesh.text = fileName;
        }

        MusicTitle title = newListItem.GetComponent<MusicTitle>();
        if (title != null)
        {
            title.index = index;
        }
    }

    private bool IsMusicFile(string fileName) =>
        fileName.EndsWith(".wav") || fileName.EndsWith(".ogg") || fileName.EndsWith(".mp3") ||
        fileName.EndsWith(".aif");
}
