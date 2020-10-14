using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FormManager : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(FormEvent());
    }

    public IEnumerator FormEvent()
    {
        var url = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSdowVJPVkj1D7FcgKx3fhW2QVnt1d_CuADbF8XpwCpdchDMOw/formResponse";
        var formData = new WWWForm();
        // Chrome上で確認したentry.~~~のIDをそれぞれ入れる。
        formData.AddField("entry.364881232","5");

        using (UnityWebRequest request = UnityWebRequest.Post(url, formData))
        {
            // ContentTypeも設定
            request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("[api]success");
            }
        }
    }
}
