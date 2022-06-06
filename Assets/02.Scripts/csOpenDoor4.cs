using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class csOpenDoor4 : MonoBehaviourPunCallbacks, IPunObservable
{
    Vector3 position;
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < 0)
        {
            position.x += 1 * Time.deltaTime;
            transform.position = position;
        }
        else
        {
            this.enabled = false;
            position = startPosition;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(position);
            stream.SendNext(startPosition);
        }
        else
        {
            this.position = (Vector3)stream.ReceiveNext();
            this.startPosition = (Vector3)stream.ReceiveNext();
        }
    }
}
