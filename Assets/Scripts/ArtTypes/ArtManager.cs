using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core;
using Ebac.Core.Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType {
        None,
        Art1,
        Art2,
        Art3,
        Art4
    }

    public List<ArtSetup> artList;

    public ArtSetup GetSetupByTaype(ArtType artType) {
        return artList.Find(x => x.artType == artType);
    }

}

[System.Serializable]
public class ArtSetup {
    public ArtManager.ArtType artType;
    public GameObject artObject;
}
