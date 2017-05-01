using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using models;

public class MainMenuManager : MonoBehaviour {

    public MenuCameraScript camera;
    public Image canvas1Image;
    public Image canvas2Image;        

    public List<Sprite> backgroundSprites;

    public float startFadeTime;
    public float preFadeTimer;
    public bool fading;
    public float fadeTimer;
    public float fadeTime;

    public float moveTimer;
    public float moveTime;

    public float xMoveDistance;
    public float yMoveDistance;
    

    public int currentCanvasID;

    public Character currentCharacter;
    public Text characterNameIndicator;
    public InputField characterNameInputField;
    
    // Use this for initialization
    void Start () {
        fadeTimer = 0f;
        moveTimer = 0f;
        currentCanvasID = 1;
        updateCharacternameIndicator();
    }
	
	// Update is called once per frame
	void Update () {
        Image currentCanvasImage = (currentCanvasID == 1) ? canvas1Image : canvas2Image;
        Canvas currentCanvas = currentCanvasImage.GetComponentInParent<Canvas>();
        if (preFadeTimer < startFadeTime)
        {
            fading = false;
            preFadeTimer += Time.deltaTime;
        }
        else
        {
            fading = true;
        }

        if (fading)
        {
            fadeTimer += Time.deltaTime;
            currentCanvasImage.color = Color.Lerp(Color.white, Color.clear, (fadeTimer / fadeTime));
        }
        //if (moveTimer < moveTime)
        //{
        //    currentCanvas.transform.position = Vector3.Lerp(new Vector3(0, 0, 574), new Vector3(xMoveDistance, yMoveDistance, 574), (moveTimer / moveTime));
        //    moveTimer += Time.deltaTime;
        //}

        if (fadeTimer > fadeTime)
        {
            switchCanvas();
            currentCanvas.transform.position = new Vector3(0, 0, 574);            
            fading = false;
            preFadeTimer = 0f;
            fadeTimer = 0f;
            moveTimer = 0f;
        }
	}

    private void randomCanvasImage(Image canvasImage)
    {
        List<Sprite> validSprites = new List<Sprite>(backgroundSprites);
        validSprites.Remove(canvas1Image.sprite);
        validSprites.Remove(canvas2Image.sprite);

        int index = Random.Range(0, validSprites.Count - 1);
        canvasImage.sprite = validSprites[index];
    }
    private void switchCanvas()
    {
        Canvas currentCanvas;
        Canvas otherCanvas;
        if (currentCanvasID == 1)
        {
            currentCanvas = canvas1Image.GetComponentInParent<Canvas>();
            otherCanvas = canvas2Image.GetComponentInParent<Canvas>();

            currentCanvasID = 2;
        }
        else
        {
            currentCanvas = canvas2Image.GetComponentInParent<Canvas>();
            otherCanvas = canvas1Image.GetComponentInParent<Canvas>();

            currentCanvasID = 1;
        }

        currentCanvas.sortingOrder = 0;
        otherCanvas.sortingOrder = 1;
        Image backImage = currentCanvas.GetComponentInChildren<Image>();
        backImage.color = Color.white;
        randomCanvasImage(backImage);
    }

    public void enterCharacterSelect()
    {
        camera.desiredRotation = 90f;
    }
    public void exitCharacterSelect()
    {
        currentCharacter.name = characterNameInputField.text;
        camera.desiredRotation = 0f;
    }

    public void updateCharacternameIndicator()
    {
        characterNameIndicator.text = currentCharacter.name;
    }

    public void hostGame()
    {
        AutoFade.LoadLevel("NYMapScene", 2f, 2f, Color.black);
    }

    public void enterJoinGameMenu()
    {
        camera.desiredPosition = new Vector3(0, 800, 0);
    }

    public void connectToGame()
    {
        AutoFade.LoadLevel("NYMapScene", 2f, 2f, Color.black);
    }
}
