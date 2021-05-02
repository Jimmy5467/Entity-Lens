using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Home2brow : MonoBehaviour
{
   public void SceneLoader(int index)
   {
       SceneManager.LoadScene(index);
   }
}
