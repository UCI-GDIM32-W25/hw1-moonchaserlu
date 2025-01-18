using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _numSeedsLeft=_numSeeds;
        _numSeedsPlanted=0;
        _plantCountUI.UpdateSeeds(_numSeedsLeft,_numSeedsPlanted);
    }

    private void Update()
    {
        // WASD to move
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (direction != Vector3.zero)
        {
            transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
        }
        //use PlantSeed method
        if(_numSeedsLeft>0){
            if (Input.GetKeyDown(KeyCode.Space)){
                 PlantSeed ();
                _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
            }
        }

       
         
       
        
    }

    public void PlantSeed ()
    {
        Instantiate(_plantPrefab,_playerTransform.position,Quaternion.identity);
        _numSeedsPlanted++;
        _numSeedsLeft=_numSeeds-_numSeedsPlanted;
    }
}