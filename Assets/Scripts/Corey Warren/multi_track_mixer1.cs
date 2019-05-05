using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multi_track_mixer1 : MonoBehaviour
{

    [SerializeField]
    private int numberOfTracks, refreshFrames;
    [Range(0.0f, 1.0f)]
    public List<float> trackVolumes = new List<float>();
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private List<float> trackMaxVols = new List<float>();
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private List<float> trackMinVols = new List<float>();
    [SerializeField]
    private List<float> volumeDistRatio = new List<float>();
    
    [SerializeField]
    private List<GameObject> trackObject = new List<GameObject>();
    [SerializeField]
    private List<AudioClip> trackClips = new List<AudioClip>();
    private List<AudioSource> trackAudio = new List<AudioSource>();

    [SerializeField]
    private List<float> trackDistances = new List<float>();
    private int t;

    

    private void Start()
    {
        
        for(int i = 0; i < numberOfTracks; i++)
        {
            trackAudio.Add((AudioSource)this.gameObject.AddComponent<AudioSource>());
            trackAudio[i].clip = trackClips[i];
        }

        
    }


    // Update is called once per frame
    void Update()
    {
        

        if (t <= 0)
        {
            float px = transform.parent.transform.position.x;
            float py = transform.parent.transform.position.y;
            float pz = transform.parent.transform.position.z;

            //Finding
            numberOfTracks = GameObject.FindGameObjectsWithTag("Audio Enemy").Length;
            for (int i = 0; i < numberOfTracks; i++)
            {
                if(trackAudio.Count < numberOfTracks)
                {
                    trackAudio.Add((AudioSource)this.gameObject.AddComponent<AudioSource>());
                    
                    Resize<AudioClip>(trackClips, numberOfTracks);
                    Resize<GameObject>(trackObject, numberOfTracks);
                    Resize<float>(trackMinVols, numberOfTracks);
                    Resize<float>(trackMaxVols, numberOfTracks);
                    Resize<float>(volumeDistRatio, numberOfTracks);
                    Resize<float>(trackVolumes, numberOfTracks);
                    Resize<float>(trackDistances, numberOfTracks);
                    
                }
                

                
                trackObject[i] = GameObject.FindGameObjectsWithTag("Audio Enemy")[i];
                volumeDistRatio[i] = trackObject[i].GetComponent<audioForMixer>().distanceRatio;
                trackMinVols[i] = trackObject[i].GetComponent<audioForMixer>().minVol;
                trackMaxVols[i] = trackObject[i].GetComponent<audioForMixer>().maxVol;
                trackClips[i] = trackObject[i].GetComponent<audioForMixer>().myclip;
                trackAudio[i].clip = trackClips[i];

                

            }
            

            //Update volumes, according to distance.
            for (int i = 0; i < numberOfTracks; i++)
            {
                Vector3 mixingPos = trackObject[i].transform.position;
                trackDistances[i] = Mathf.Abs(mixingPos.x - px) + Mathf.Abs(mixingPos.y - py) + Mathf.Abs(mixingPos.z - pz);
                trackVolumes[i] = volumeDistRatio[i] / trackDistances[i];



                if (trackVolumes[i] < trackMinVols[i])
                {
                    trackVolumes[i] = trackMinVols[i];
                }
                else
                if (trackVolumes [i] > trackMaxVols[i])
                {
                    trackVolumes[i] = trackMaxVols[i];
                }




                trackAudio[i].volume = trackVolumes[i];
                if(!trackAudio[i].isPlaying)
                {
                    trackAudio[i].Play();
                }
                
            }


            t = refreshFrames;
        }
        else { t--; }
        


    }

    void Resize<T>(List<T> list, int newCount)
    {
        if (newCount <= 0)
        {
            list.Clear();
        }
        else
        {
            while (list.Count > newCount) list.RemoveAt(list.Count - 1);
            while (list.Count < newCount) list.Add(default(T));
        }
    }



}


