using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class targetData : MonoBehaviour
    {

        public Transform TextDescription1;
        public Transform TextDescription2;
        public Transform PanelDescription;

        // Use this for initialization
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);

                //Everytime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

               
                TextDescription1.gameObject.SetActive(true);
                TextDescription2.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);


                //If the target name was “zombie” then add listener to ButtonAction with location of the zombie sound (locate in Resources/sounds folder) and set text on TextDescription a description of the zombie

                if (name == "LOGO_AR4_kukur")
                {

                    TextDescription1.GetComponent<Text>().text = "Kukur ialah sejenis alat bergerigi yang digunakan untuk mengikis isi kelapa. Kukur ini juga mempunyai bahagian untuk duduk yang memberi keselesaan dalam proses mengukur kelapa.";
                    TextDescription2.GetComponent<Text>().text = "Kukur is a jaggel tool that is used to scrape coconut flesh. It has a sitting area which can provide comfort in the process of scraping coconuts.";

                }



                //If the target name was “unitychan” then add listener to ButtonAction with location of the unitychan sound (locate in Resources/sounds folder) and set text on TextDescription a description of the unitychan / robot

                if (name == "LOGO_AR4_dapur")
                {
                    
                    TextDescription1.GetComponent<Text>().text = "Dapur kayu api terdiri daripada ranting, dahan, dan batang kayu yang dipotong. Terdapat juga tungku untuk meletak periuk dan api yang dihidupkan menggunakan mancis. Api tersebut perlulah dikawal ketika memasak dengan meniup bara menggunakan buluh.";
                    TextDescription2.GetComponent<Text>().text = "Firewood pot consists of wooden twigs, branches, cut trunks, fireplace pots and fire that are lighted up by matches. The fire must be controlled when cooking by blowing an ember using a bamboo stick.";

                }


                if (name == "LOGO_AR4_batu_giling")
                {

                    TextDescription1.GetComponent<Text>().text = "Batu giling ialah alat yang digunakan untuk menghancurkan cili dan rempah ratus. Ia terdiri daripada dua bahagian iaitu batu hampar dan batu penggiling.";
                    TextDescription2.GetComponent<Text>().text = "Metate is a tool that is used to grind chillies and spices. It consists of two parts that are bedrock and grinding stone.";

                }


				if (name == "LOGO_AR4_lampu_pam") {

					TextDescription1.GetComponent<Text> ().text = "Lampu pam ialah sejenis lampu yang menggunakan minyak tanah sebagai bahan pembakaran. Lampu ini menggunakan pam untuk menaikkan minyak. Mentol diikat pada bahagian atas lampu manakala pam dan meter tekanan terletak di bahagian sisi lampu.";
					TextDescription2.GetComponent<Text> ().text = "Pump lamp is a kind of lamp that uses kerosene as a combustion material. This lamp uses pump to rise oil. The bulb is tied at the top of the lamp while the pump and the pressure meter are located at the side of the lamp. ";

				}

                if (name == "FISHAR_Logo")
                {

                    TextDescription1.GetComponent<Text>().text = "Imbas pelekat FishAR untuk melihat video. Imbas nombor(02, 03, 06 atau 08) untuk melihat animasi 2D. ";
                    TextDescription2.GetComponent<Text>().text = "Scan the FishAR sticker to see the video. Scan the numbers(either 02, 03, 06 or 08) to see the 2D animation.  ";

                }
					
            }
				
        }

  
    }
}
