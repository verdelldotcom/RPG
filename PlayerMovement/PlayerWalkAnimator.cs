using UnityEngine;
using VeesInputActions;
using VeesSaveSystem;
namespace VeesPlayerMovement 
{
    public sealed class PlayerWalkAnimator : MonoBehaviour
    {
        PlayerInfo _playerInfo;
        public enum FacingDirection { Down, Left, Up ,Right}

        public Animator _player_skin_animator;
        public Animator _player_hair_animator;

        IA_Player _IA_player;

        public FacingDirection _facing_direction;

        public static int _x_dir_hash = Animator.StringToHash("X_Dir");
        public static int _y_dir_hash = Animator.StringToHash("Y_Dir");
        public static int _facing_direction_hash = Animator.StringToHash("Facing_Dir");
        public static int _magnitude_hash = Animator.StringToHash("Magnitude");

        public bool _can_animate;

        private void Awake()
        {
            _IA_player = new();
            _player_hair_animator = transform.Find("Hair_Animator").GetComponent<Animator>();

            _player_skin_animator = GetComponent<Animator>();
        }

        public void LoadSkinAnimator()
        {
            _playerInfo = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>();



           SpawnAddressables.LoadSkinAnimator(_playerInfo.Skin_animator_address);

        }

        public void LoadHairAnimator()
        {
            SpawnAddressables.LoadHairAnimator(_playerInfo.Hair_animator_address);
        }

        void OnEnable()
        {
            _IA_player.Enable();
        }
        void OnDisable()
        {
            _IA_player.Disable();
        }

        Vector2 _movement;

        void Update()
        {
            if (_can_animate) 
            {
                _movement.x = _IA_player.Player.Move.ReadValue<Vector2>().x;
                _movement.y = _IA_player.Player.Move.ReadValue<Vector2>().y;
            }
            

            MovementAnimations();
            IdleAnimations();
        }
    
        void MovementAnimations()
        {
            _player_skin_animator.SetFloat(id: _x_dir_hash, value: _movement.x);
            _player_skin_animator.SetFloat(id: _y_dir_hash, value: _movement.y);
            _player_skin_animator.SetFloat(id: _magnitude_hash, value: _movement.magnitude);

            _player_hair_animator.SetFloat(id: _x_dir_hash, value: _movement.x);
            _player_hair_animator.SetFloat(id: _y_dir_hash, value:_movement.y);
            _player_hair_animator.SetFloat(id: _magnitude_hash, value: _movement.magnitude);

            _player_hair_animator.SetInteger(id: _facing_direction_hash, (int)_facing_direction);
            _player_skin_animator.SetInteger(id: _facing_direction_hash, (int)_facing_direction);
        }

        void IdleAnimations()
        {
            if (_movement.x > 0)
                _facing_direction = FacingDirection.Right;
             else if ( _movement.x < 0 )
                _facing_direction = FacingDirection.Left;
            else if ( _movement.y > 0 )
                _facing_direction = FacingDirection.Up; 
            else if (_movement.y < 0 )
                _facing_direction = FacingDirection.Down;
        }

        public void EnableAnimationControls() =>
            _can_animate = true;



        public void DisableAnimationControls() =>
            _can_animate = false;
    }
}

