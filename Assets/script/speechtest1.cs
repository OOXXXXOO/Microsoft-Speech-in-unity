using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.UI;
public class speechtest1 : MonoBehaviour {
    DictationRecognizer dictationRecognizer;

    //听写功能正常但需要在x86下编译则表明所有的功能都需要在x86架构下编译生效才可以确定  该功能可用后续放弃是否依据结果判定
    // Use this for initialization
    void Start()
    {
        dictationRecognizer = new DictationRecognizer();

        dictationRecognizer.DictationResult += onDictationResult;
        dictationRecognizer.DictationHypothesis += onDictationHypothesis;
        dictationRecognizer.DictationComplete += onDictationComplete;
        dictationRecognizer.DictationError += onDictationError;

        dictationRecognizer.Start();
    }

    void onDictationResult(string text, ConfidenceLevel confidence)
    {
        // write your logic here
        Debug.LogFormat("Dictation result: " + text);
        
    }

    void onDictationHypothesis(string text)
    {
        // write your logic here
        Debug.LogFormat("Dictation hypothesis: {0}", text);
    }

    void onDictationComplete(DictationCompletionCause cause)
    {
        // write your logic here
        if (cause != DictationCompletionCause.Complete)
            Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", cause);
    }

    void onDictationError(string error, int hresult)
    {
        // write your logic here
        Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
    }




}
