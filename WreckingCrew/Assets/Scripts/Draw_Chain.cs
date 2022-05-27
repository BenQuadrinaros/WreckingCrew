using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Chain : MonoBehaviour
{
    public Transform tr_topJoint;
    public List<Transform> between_joints;
    public Transform tr_bottomJoint;

    public GameObject Prefab_LineTracer;
    private List<LineRenderer> traced_lines;

    // Start is called before the first frame update
    void Start()
    {
        traced_lines = new List<LineRenderer>();

        LineRenderer top_line = Instantiate(Prefab_LineTracer, transform).GetComponent<LineRenderer>();
        top_line.SetPosition(0, tr_topJoint.position);
        top_line.SetPosition(1, between_joints[0].position);
        traced_lines.Add(top_line);
        for(int i = 0; i < between_joints.Count-1; ++i) {
            LineRenderer new_line = Instantiate(Prefab_LineTracer, transform).GetComponent<LineRenderer>();
            new_line.SetPosition(0, between_joints[i].position);
            new_line.SetPosition(1, between_joints[i+1].position);
            traced_lines.Add(new_line);
        }
        LineRenderer bottom_line = Instantiate(Prefab_LineTracer, transform).GetComponent<LineRenderer>();
        bottom_line.SetPosition(0, between_joints[between_joints.Count-1].position);
        bottom_line.SetPosition(1, tr_bottomJoint.position);
        traced_lines.Add(bottom_line);
    }

    // Update is called once per frame
    void Update()
    {
        traced_lines[0].SetPosition(0, tr_topJoint.position);
        traced_lines[0].SetPosition(1, between_joints[0].position);
        for(int i = 1; i < traced_lines.Count-1; ++i) {
            traced_lines[i].SetPosition(0, between_joints[i-1].position);
            traced_lines[i].SetPosition(1, between_joints[i].position);
        }
        traced_lines[traced_lines.Count-1].SetPosition(0, between_joints[between_joints.Count-1].position);
        traced_lines[traced_lines.Count-1].SetPosition(1, tr_bottomJoint.position);
    }
}
