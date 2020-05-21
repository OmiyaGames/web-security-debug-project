using System.Collections;
using System.Text;
using UnityEngine;
using OmiyaGames.Web.Security;

public class TestRedirect : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    int waitForSeconds = 10;
    [SerializeField]
    string redirectTo = "https://omiyagames.com";
    [SerializeField]
    TMPro.TextMeshProUGUI label;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        StringBuilder builder = new StringBuilder();
        WaitForSeconds waitFor = new WaitForSeconds(1);
        for (int secondsLeft = waitForSeconds; secondsLeft > 0; --secondsLeft)
        {
            label.text = DebugMessage(builder, secondsLeft);
            yield return waitFor;
        }
        WebLocationChecker.RedirectTo(redirectTo);
    }

    private string DebugMessage(StringBuilder builder, int secondsLeft)
    {
        builder.Clear();
        builder.Append("Calling RedirectTo('");
        builder.Append(redirectTo);
        builder.Append("') in ");
        builder.Append(secondsLeft);
        builder.Append(" second");
        if (secondsLeft > 1)
        {
            builder.Append("s");
        }
        builder.AppendLine();
        return builder.ToString();
    }
}
