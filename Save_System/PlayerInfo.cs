using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using VeesPlayerMovement;


    public sealed class PlayerInfo : MonoBehaviour
    {
        public static PlayerInfo instance { get; private set; }
        PlayerWalkAnimator _player_walk_animator;

        public string Hair_animator_address = "Assets/Prefabs/Addresable_Prefabs/HairAnimations/Male/M_Crimson_Hair_Prefab.prefab";
        public string Skin_animator_address = "Assets/Prefabs/Addresable_Prefabs/Player_Skin_Animators/Desert_Tan.prefab";
        public string Player_name = "Veee.exe";
        public string Directory_to_load;


        private void Awake()
        {
            SetSkinAnimator("Assets/Prefabs/Addresable_Prefabs/Player_Skin_Animators/Desert_Tan.prefab");
            SetHairAnimator("Assets/Prefabs/Addresable_Prefabs/HairAnimations/Male/M_Crimson_Hair_Prefab.prefab");

            if (instance != null)
            {
                if (instance != this)
                {
                    Destroy(this);
                }
                else
                {
                    instance = this;
                }
            }
            else
            {
                instance = this;
            }
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scenename, LoadSceneMode scene)
        {
            if (File.Exists(Application.persistentDataPath + "\\PlayerInfo.Data"))
            {
                BinPractice practice = GameObject.Find("Save System").GetComponent<BinPractice>();
                practice.LoadPlayerInfo();
                _player_walk_animator = GameObject.Find("Player").GetComponent<PlayerWalkAnimator>();
                _player_walk_animator.LoadSkinAnimator();
                _player_walk_animator.LoadHairAnimator();
            }

        }


        private void Start()
        {
            DontDestroyOnLoad(this);

            if (File.Exists(Application.persistentDataPath + "\\PlayerInfo.Data"))
            {
                BinPractice practice = GameObject.Find("Save System").GetComponent<BinPractice>();
                practice.LoadPlayerInfo();
            }
        }

        public void SetHairAnimator(string address)
        {
            Hair_animator_address = address;
        }

        public void SetSkinAnimator(string address)
        {
            Skin_animator_address = address;
        }
    }

