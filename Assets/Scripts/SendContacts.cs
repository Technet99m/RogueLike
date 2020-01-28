using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class SendContacts : MonoBehaviour
{

    public void SendMessage()
    {
        Application.ExternalEval("window.open(\"https://t-do.ru/gamesmm\")");

    }

}
