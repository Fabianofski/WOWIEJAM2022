#if UNITY_2019_1_OR_NEWER
using Atoms.Generated;
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `F4B1.Core.Dialogue`. Inherits from `AtomEventEditor&lt;F4B1.Core.Dialogue, DialogueEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(DialogueEvent))]
    public sealed class DialogueEventEditor : AtomEventEditor<Dialogue, DialogueEvent> { }
}
#endif
