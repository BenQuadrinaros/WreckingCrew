using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //Scene references
    public Transform player_crane;
    public Transform tiltFive_board;

    public List<Transform> cloud_clusters;
    private Vector3 cloud_direction;
    private Vector2 cloud_bounds;

    // Start is called before the first frame update
    void Start()
    {
        cloud_direction = new Vector3(Random.Range(2, 5), 0, Random.Range(0.5f, 3));
        if(Random.Range(0,2)>1) {
            cloud_direction.x *= -1;
        }
        if(Random.Range(0,2)>1) {
            cloud_direction.z *= -1;
        }

        cloud_bounds = new Vector2(-30, 30);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta_center = player_crane.position - tiltFive_board.position;
        if(delta_center.sqrMagnitude > 10) {
            tiltFive_board.position += delta_center*Time.deltaTime;
        }

        foreach(Transform cloud in cloud_clusters) {
            cloud.position += Time.deltaTime*cloud_direction;
            if(cloud.position.x < cloud_bounds.x) {
                cloud.position += new Vector3(cloud_bounds.y - cloud_bounds.x, 0, 0);
            } else if(cloud.position.x > cloud_bounds.y) {
                cloud.position += new Vector3(cloud_bounds.x - cloud_bounds.y, 0, 0);
            }

            if(cloud.position.z < cloud_bounds.x) {
                cloud.position += new Vector3(0, 0, cloud_bounds.y - cloud_bounds.x);
            } else if(cloud.position.z > cloud_bounds.y) {
                cloud.position += new Vector3(cloud_bounds.x - cloud_bounds.y, 0, 0);
            }
        }
    }
}
