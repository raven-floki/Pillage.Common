using Dalamud.Interface.Components;
using Dalamud.Bindings.ImGui;

namespace Pillage.Common.Configuration;

public static class ConfigGui
{
    #region SECTIONS
    public static void SectionStart(string sectionTitle, bool seperator = true)
    {
        ImGui.Spacing();
        ImGui.Spacing();
        ImGui.TextUnformatted(sectionTitle);
        if (seperator) ImGui.Separator();
        ImGui.Indent();
    }

    public static void SectionEnd()
    {
        ImGui.Unindent();
        ImGui.Spacing();
    }

    public static void DisableSection(bool disabled)
    {
        if (disabled)
            ImGui.BeginDisabled();
    }

    public static void DisableSectionEnd(bool disabled)
    {
        if (disabled)
            ImGui.EndDisabled();
    }
    #endregion

    #region CONFIG INTERFACE COMPONENTS
    public static void Checkbox(string label, ref bool configProperty, string tooltip = "")
    {
        if (ImGui.Checkbox(label, ref configProperty))
            PillageConfiguration.Save();

        if (tooltip != "")
        {
            ImGui.SameLine();
            //ImGuiUtil.Tooltip(tooltip);
        }
    }

    public static bool Checkbox(string label, ref bool refValue, string helpText = "", bool hoverHelpText = false)
    {
        bool clicked = false;

        if (ImGui.Checkbox($"{label}", ref refValue))
        {
            clicked = true;
            //Service.Save();
        }

        if (helpText != string.Empty)
        {
            if (hoverHelpText)
            {
                if (ImGui.IsItemHovered())
                    ImGui.SetTooltip(helpText);
            }
            else
                ImGuiComponents.HelpMarker(helpText);
        }

        return clicked;
    }

    public static bool ChildCheckbox(string label, ref bool refValue, string helpText = "", bool hoverHelpText = false)
    {
        ChildOptionIcon();
        return Checkbox(label, ref refValue, helpText, hoverHelpText);
    }

    public static void SliderInt(string title, string label, ref int value, int minValue = 0, int maxValue = 100)
    {
        ImGui.TextUnformatted(title);
        ImGui.SetNextItemWidth(300);
        if (ImGui.SliderInt(label, ref value, minValue, maxValue)) ;
        //Config.Save();
    }

    public static void SliderFloat(string title, string label, ref float value)
    {
        ImGui.TextUnformatted(title);
        ImGui.SetNextItemWidth(300);
        if (ImGui.SliderFloat($"{label}##{title}", ref value, .1f, 10f, "%.1f")) ;// Config.Save();
        ImGui.Spacing();
    }
    //ImGuiComponents.HelpMarker
    public static void CreateDropDown(string title, string currentSelection, ref uint currentValueRef, Dictionary<string, uint> items)
    {
        ImGui.Spacing();
        ImGui.Spacing();
        ImGui.TextUnformatted(title);
        ImGui.Indent();
        ImGui.SetNextItemWidth(300);
        if (ImGui.BeginCombo("", currentSelection))
        {
            //if (ImGui.Selectable("", Config.SelectedMountRowId == 0))
            //{
            //    //Config.SelectedMountRowId = 0;
            //    //Config.Save();
            //}

            foreach (var (name, id) in items)
            {
                var selected = ImGui.Selectable(name, currentValueRef == id);

                if (selected)
                {
                    currentValueRef = id;
                    //Config.Save();
                }
            }

            ImGui.EndCombo();
        }
        ImGui.Unindent();
    }
    #endregion

    #region GENERAL COMPONENTS
    public static void EmptyLines(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            ImGui.Spacing();
        }
    }

    public static void ChildOptionIcon()
    {
        TextV($" └");
        ImGui.SameLine();
    }
    #endregion

    #region INTERNAL COMPONENTS
    private static void TextV(string s)
    {
        var cur = ImGui.GetCursorPos();
        ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0);
        ImGui.Button("");
        ImGui.PopStyleVar();
        ImGui.SameLine();
        ImGui.SetCursorPos(cur);
        ImGui.TextUnformatted(s);
    }
    #endregion
}
