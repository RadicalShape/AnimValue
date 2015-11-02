using System;
using RadicalShape;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimExample : MonoBehaviour
{
	public string[] Messages;
	public GameObject GameObject;
	public TextMesh TextMesh;

	private Transform mTransform;
	private Renderer mRenderer;

	private int mCurrentMessageIndex;
	private bool mAllowInteraction;

	private AnimVector3 mAnimPosition;
	private AnimQuaternion mAnimRotation;
	private AnimColor mAnimColor;
	private AnimString mAnimText;

	private void Start()
	{
		mTransform = GameObject.transform;
		mRenderer = GameObject.GetComponent<Renderer>();

		mAnimPosition = new AnimVector3(Vector3.zero, Vector3.back * 2, 0.67f);
		mAnimPosition.EaseType = AnimEasing.EaseType.EaseInOutBack;
		mAnimPosition.OnUpdate += OnUpdatePosition;

		mAnimRotation = new AnimQuaternion(Quaternion.identity, Quaternion.identity, 0.5f);
		mAnimRotation.EaseType = AnimEasing.EaseType.EaseOutCirc;
		mAnimRotation.OnUpdate += OnUpdateRotation;
		mAnimRotation.OnFinish += OnFinishRotation;

		mAnimColor = new AnimColor(Color.red, Color.yellow, 2);
		mAnimColor.EaseType = AnimEasing.EaseType.EaseInOutCirc;
		mAnimColor.OnUpdate += OnUpdateColor;
		mAnimColor.OnFinish += OnFinishColor;

		mAnimText = new AnimString("", Messages[0], 2);
		mAnimText.EaseType = AnimEasing.EaseType.EaseOutCubic;
		mAnimText.OnUpdate += OnUpdateText;
		mAnimText.OnFinish += OnFinishText;

		mCurrentMessageIndex++;
	}

	private void OnUpdatePosition(Vector3 position)
	{
		mTransform.position = position;
	}

	private void OnUpdateRotation(Quaternion rotation)
	{
		mTransform.rotation = rotation;
		TextMesh.transform.rotation = Quaternion.identity;
	}

	private void OnFinishRotation(Quaternion rotation)
	{
		mAnimRotation.TargetValue = Quaternion.AngleAxis(Random.Range(-45f, 45f), Vector3.up);
	}

	private void OnUpdateColor(Color color)
	{
		mRenderer.material.color = color;
	}

	private void OnFinishColor(Color color)
	{
		mAnimColor.TargetValue = color == Color.yellow ? Color.red : Color.yellow;
	}

	private void OnUpdateText(string s)
	{
		TextMesh.text = s;
	}

	private void OnFinishText(string s)
	{
		if (mCurrentMessageIndex > Messages.Length - 1)
		{
			mAnimText.TargetValue = "";
			mAllowInteraction = true;

			return;
		}

		mAnimText.TargetValue = Messages[mCurrentMessageIndex];
		mCurrentMessageIndex++;
	}
	
	private void Update()
	{
		if (!Input.GetMouseButtonUp(0) || !mAllowInteraction) 
			return;

		var plane = new Plane(Vector3.up, Vector3.zero);
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		var distance = 0f;

		if (plane.Raycast(ray, out distance))
		{
			var pos = ray.GetPoint(distance);

			mAnimPosition.TargetValue = pos;
			mAnimText.TargetValue = mAnimText.TargetValue == "Wow! " ? "Okey... " : "Wow! ";
		}
	}

	private void OnGUI()
	{
		var s = mAllowInteraction ? "Interaction with Cube is allowed" : "Interaction with Cube is not allowed";

		GUI.color = Color.black;
		GUILayout.Label(s);
	}
}
