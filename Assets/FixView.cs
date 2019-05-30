using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixView : MonoBehaviour
{


  public Transform WatchTarget;
  public LayerMask OccluderMask;
  //This is the material with the Transparent/Diffuse With Shadow shader
  public Material HiderMaterial;

  private Dictionary<Transform, Material> _LastTransforms;



  void Start () {
    _LastTransforms = new Dictionary<Transform, Material>();
  }

  void Update () {
    //reset and clear all the previous objects
    if(_LastTransforms.Count > 0){
      foreach(Transform t in _LastTransforms.Keys){
        t.GetComponent<Renderer>().material = _LastTransforms[t];
      }
      _LastTransforms.Clear();
    }

        RaycastHit[] hits = Physics.BoxCastAll(
            transform.position, 
            new Vector3(15f, 15f, 15f), 
            WatchTarget.transform.position - transform.position,
            new Quaternion(0,0,0,0  ),
            Vector3.Distance(WatchTarget.transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z   )), 
            OccluderMask);
//      transform.position,
  //    WatchTarget.transform.position - transform.position,
    //  Vector3.Distance(WatchTarget.transform.position, transform.position),
      //OccluderMask

    //Cast a ray from this object's transform the the watch target's transform.
 //   RaycastHit[] hits = Physics.RaycastAll(
   //   transform.position,
     // WatchTarget.transform.position - transform.position,
     // Vector3.Distance(WatchTarget.transform.position, transform.position),
      //OccluderMask
    

    //Loop through all overlapping objects and disable their mesh renderer
    if(hits.Length > 0){
      foreach(RaycastHit hit in hits){
        if(hit.collider.gameObject.transform != WatchTarget && hit.collider.transform.root != WatchTarget && Vector3.Distance(transform.position, hit.collider.transform.position) < Vector3.Distance(transform.position, WatchTarget.transform.position))
                {
                   /* Renderer[] hitchildren;
                    hitchildren = hit.collider.gameObject.GetComponentsInChildren<Renderer>(true);
                    foreach(Renderer r in hitchildren)
                    {
                        if (hit.collider.gameObject.GetComponent<Renderer>() != null && hit.collider.gameObject.transform.position.y > WatchTarget.transform.position.y + 3f)
                        {
                            _LastTransforms.Add(r.gameObject.transform, r.material);
                            r.material = HiderMaterial;
                        }
                    }*/
                    if (hit.collider.gameObject.GetComponent<Renderer>() != null && hit.collider.gameObject.transform.position.y > WatchTarget.transform.position.y + 3f)
                    {
                        _LastTransforms.Add(hit.collider.gameObject.transform, hit.collider.gameObject.GetComponent<Renderer>().material);
                        hit.collider.gameObject.GetComponent<Renderer>().material = HiderMaterial;
                    }
        }
      }
    }

  }

    
}
