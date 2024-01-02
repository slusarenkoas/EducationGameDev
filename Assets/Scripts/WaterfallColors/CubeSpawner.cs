using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace WaterfallColors
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private CoroutineManager _coroutineManager;
        [SerializeField] private Cube _enemy;
        [SerializeField] private Button _changeColorsButton;
        
        [SerializeField] private Vector2 _boardSize = new (20,20);
        [SerializeField] private float _spawnInterval = 0.04f;
        [SerializeField] private float _changeColorTime = 0.5f;
        [SerializeField] private float _changeNextEnemyColorInterval = 0.2f;
        
        private Image _changeColorsButtonImage;
        
        private Cube[,] _enemies;

        private void Awake()
        {
            _enemies = new Cube[(int)_boardSize.x, (int)_boardSize.y];
            _changeColorsButtonImage = _changeColorsButton.GetComponent<Image>();

            _coroutineManager.StartCoroutine(SpawnerEnemies());
            _changeColorsButton.onClick.AddListener(ChangeColor);
        }

        private void ChangeColor()
        {
            var randomColor = new Color(Random.value, Random.value, Random.value);
            _changeColorsButtonImage.color = randomColor;
            
            _coroutineManager.StartCoroutine(ChangeColorsCoroutine(randomColor));
        }

        private IEnumerator ChangeColorsCoroutine(Color randomColor)
        {
            for (var i = 0; i < _boardSize.x; i++)
            {
                for (var j = 0; j < _boardSize.y; j++)
                {
                    _enemies[i,j].ChangeColor(randomColor,_changeColorTime);
                    
                    yield return new WaitForSeconds(_changeNextEnemyColorInterval);
                }
            }
        }

        private IEnumerator SpawnerEnemies()
        {
            var nextPoint = new Vector3(-_boardSize.x / 2, _boardSize.y / 2, 0);
            
            for (var i = 0; i < _boardSize.x; i++)
            {
                for (var j = 0; j < _boardSize.y; j++)
                {
                    _enemies[i,j] = Instantiate(_enemy,nextPoint,Quaternion.identity);

                    yield return new WaitForSeconds(_spawnInterval);
                    
                    nextPoint.x++;
                }
                
                nextPoint.x = -_boardSize.x / 2;
                nextPoint.y--;
            }
        }
    }
}
