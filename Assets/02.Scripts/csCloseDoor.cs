using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class csCloseDoor : MonoBehaviourPunCallbacks, IPunObservable
{
    Vector3 position;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (position.x > GetComponent<csOpenDoor4>().startPosition.x)
        {
            position.x -= 1 * Time.deltaTime;
            transform.position = position;
        }
        else
        {
            this.enabled = false;
            position = lastPosition;
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(position);
            stream.SendNext(lastPosition);
        }
        else
        {
            this.position = (Vector3)stream.ReceiveNext();
            this.lastPosition = (Vector3)stream.ReceiveNext();
        }
    }
}
