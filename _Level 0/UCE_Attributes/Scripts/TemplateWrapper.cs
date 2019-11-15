using UnityEngine;

[System.Serializable]
public class TemplateWrapper
{
    [SerializeField]
    private UCE_AttributeTemplate template;


    private string objectName = string.Empty;

    public string ObjectName
    {
        get { return objectName; }
        set { objectName = value; }
    }

    public static implicit operator string(TemplateWrapper template)
    {
        return template.objectName;
    }

    public bool IsSet()
    {
        return !string.IsNullOrEmpty(objectName);
    }
}