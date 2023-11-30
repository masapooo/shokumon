using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AAA.OpenAI;

public class SendMessage : MonoBehaviour
{
    
    [SerializeField] private Text message;
   public void OnClick()
   {
        var openAIApiKey = "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";
        var chatGPTConnection = new ChatGPTConnection(openAIApiKey);
        chatGPTConnection.RequestAsync("{{" + message.text + "}}");
   }
}
