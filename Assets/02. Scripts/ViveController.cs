using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;

public class ViveController : MonoBehaviour
{
    //Controller 정의
    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources any;

    //Controller 입력값 정의
    public SteamVR_Action_Boolean trigger;

    //TrackPad 클릭 여부
    public SteamVR_Action_Boolean trackPadClick = SteamVR_Actions.default_Teleport;
    public SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_TrackPadTouch;
    public SteamVR_Action_Vector2 trackPadPosition = SteamVR_Actions.default_TrackPadPosition;



    private void Awake()
    {
        trigger = SteamVR_Actions.default_InteractUI;
    }


    void Update()
    {
        //왼손 컨트롤러의 트리거 버튼을 클릭했을 때 발생
        //if (SteamVR_Actions.default_InteractUI.GetStateDown(SteamVR_Input_Sources.LeftHand))
        if (trigger.GetStateDown(leftHand))
        {
            print("Clicked Trigger Button");
        }

        //오른손 컨트롤러의 트리거 버튼을 릴리스했을 때 발생
        if (trigger.GetStateUp(rightHand))
        {
            print("Release Trigger Button");
        }

        //TrackPad 클릭
        if (trackPadClick.GetStateDown(any))
        {
            print("TrackPad Click");
        }

        if (trackPadTouch.GetState(any))
        {
            Vector2 pos = trackPadPosition.GetAxis(any);
            Debug.Log($"Touch Pos x={pos.x}/y={pos.y}");
            //
        }

        if (trackPadClick.GetStateDown(any))
        {
            print("TrackPad Clicked");
        }
    }
}
