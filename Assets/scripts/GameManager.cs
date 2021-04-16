using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuGameOver;
    public GameObject menuPrincipal;
    public Renderer fondo;
    public GameObject col;
    public List<GameObject> cols;
    public float velocidad = 2;
    public GameObject piedra1;
    public GameObject piedra2;
    public List<GameObject> obstaculos;
    public bool gameOver = false;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        //creando mapa
        for(int i=0; i<21;i++)
        {
           cols.Add( Instantiate(col,new Vector2(-10 + i,-3), Quaternion.identity));
        }
        //creacion de piedras
        obstaculos.Add(Instantiate(piedra1, new Vector2(14, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra2, new Vector2(18, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {   if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start =true; 
            }
        }
        if (start == true && gameOver== true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (start == true && gameOver==false )
        {
            menuPrincipal.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;
            //mover mapa
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -10)
                {
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;

            }
            //movimiento de obstaculos
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);
                    obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;

            }
        }
    }
    }
