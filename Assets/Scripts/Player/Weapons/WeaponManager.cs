using UnityEngine;

namespace Player.Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        private int _numberOfWeapons = 1;
        public int activeGunIndex;

        public GameObject[] guns;
        public GameObject gunHolder;
        public GameObject activeGun;


        // Start is called before the first frame update
        private void Start()
        {
            _numberOfWeapons = gunHolder.transform.childCount;
            guns = new GameObject[_numberOfWeapons];

            for (int i = 0; i < _numberOfWeapons; i++) 
            {
                guns[i] = gunHolder.transform.GetChild(i).gameObject;
                guns[i].SetActive(false);
            }

            guns[0].SetActive(true);
            activeGun = guns[0];
            activeGunIndex = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                if (activeGunIndex < _numberOfWeapons - 1) 
                {
                    guns[activeGunIndex].SetActive(false);
                    activeGunIndex += 1;
                    guns[activeGunIndex].SetActive(true);
                    activeGun = guns[activeGunIndex];
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (activeGunIndex > 0)
                {
                    guns[activeGunIndex].SetActive(false);
                    activeGunIndex -= 1;
                    guns[activeGunIndex].SetActive(true);
                    activeGun = guns[activeGunIndex];
                }

            }

        }
    }
}
