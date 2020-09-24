using System.Collections.Generic;
using System.Windows.Forms;
using ExileCore.RenderQ;
using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace ExileCore
{
    public class CoreSettings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(true);


        #region main
        [Menu("Main", 1000)]
        public EmptyNode EmptyMain { get; set; } = new EmptyNode();
        [Menu("��s�ϰ�C", 1, 1000)]
        public ButtonNode RefreshArea { get; set; } = new ButtonNode();
        [Menu("�M��]�w�ɡC", "��e�L�k���`�u�@�C�ܧ֡C", 2, 1000)]
        public ListNode Profiles { get; set; } = new ListNode { Values = new List<string> { "global" }, Value = "global" };
        [Menu("�\���������C", 3, 1000)]
        public HotkeyNode MainMenuKeyToggle { get; set; } = Keys.F12;
        [Menu("�j��m���C", 4, 1000)]
        public ToggleNode ForceForeground { get; set; } = new ToggleNode(false);
        [Menu("�۰ʤU����s�C", 5, 1000)]
        public ToggleNode AutoPrepareUpdate { get; set; } = new ToggleNode(true);
        #endregion

        #region messages
        [Menu("Messages", 2000)]
        public EmptyNode EmptyMessages { get; set; } = new EmptyNode();
        [Menu("�ҥθ�T�����C", "�N�l����ܦb��x�������C", 1, 2000)]
        public ToggleNode ShowInformationMessages { get; set; } = new ToggleNode(true);
        [Menu("�ҥο��~�����C", "�N�l����ܦb��x�������C", 2, 2000)]
        public ToggleNode ShowErrorMessages { get; set; } = new ToggleNode(true);
        [Menu("�ҥνոծ����C", "(De)�]�Ұʤ�x�����������ءC", 3, 2000)]
        public ToggleNode ShowDebugMessages { get; set; } = new ToggleNode(false);
        [Menu("��ܤ�x�����C", 4, 2000)]
        public ToggleNode ShowDebugLog { get; set; } = new ToggleNode(false);
        [Menu("��ܽոյ����C", 5, 2000)]
        public ToggleNode ShowDebugWindow { get; set; } = new ToggleNode(false);
        [Menu("�ոո�T�C", "�ϥγo�ӿﶵ,�z�i�H�ˬd�C�ӥ~���{�����u�@�覡�C.", 6, 2000)]
        public ToggleNode CollectDebugInformation { get; set; } = new ToggleNode(false);
        [Menu("��xŪ���O������~�C", 7, 2000)]
        public ToggleNode LogReadMemoryError { get; set; } = new ToggleNode(false);
        #endregion

        #region performance
        [Menu("�ʯ�C", 3000)]
        public EmptyNode EmptyPerfomance { get; set; } = new EmptyNode();
        [Menu("�u�{�p�ơC", 1, 3000)]
        public RangeNode<int> Threads { get; set; } = new RangeNode<int>(1, 0, 4);
        [Menu("HUD VSync", 2, 3000)]
        public ToggleNode VSync { get; set; } = new ToggleNode(false);
        [Menu("�ʺA�C FPS", "Hud FPS like FPS game", 3, 3000)]

        public ToggleNode DynamicFPS { get; set; } = new ToggleNode(false);
        [Menu("Percent �q�C���C FPS", 4, 3000)]
        public RangeNode<int> DynamicPercent { get; set; } = new RangeNode<int>(100, 1, 150);
        [Menu("�ʺA�ɳ̤֪� FPS�C", 5, 3000)]
        public RangeNode<int> MinimalFpsForDynamic { get; set; } = new RangeNode<int>(60, 10, 150);

        [Menu("�ؼСC FPS", 6, 3000)]
        public RangeNode<int> TargetFps { get; set; } = new RangeNode<int>(60, 5, 200);
        [Menu("�ؼХ���G�k�C Fps", 7, 3000)]
        public RangeNode<int> TargetParallelFPS { get; set; } = new RangeNode<int>(60, 30, 500);
        [Menu("Entites FPS", "�ݭn�p��g�`��s����C�z�i�H�b���������ݨ�C->Coroutines �ɶ���F����u�@�C", 8, 3000)]
        public RangeNode<int> EntitiesUpdate { get; set; } = new RangeNode<int>(60, 5, 200);
        [Menu("�ѪR���A������C", 10, 3000)]
        public ToggleNode ParseServerEntities { get; set; } = new ToggleNode(false);
        [Menu("�b�W�L�C X", 11, 3000)]
        public ToggleNode CollectEntitiesInParallelWhenMoreThanX { get; set; } = new ToggleNode(false);
        [Menu("�bms������ø�s�ϡC",
            "���n��p��,�]��ø�ϻݭn�ܦh�T���ΩM�ոյ����P�ܦh���`�N�Q���}�C", 12, 3000)]
        public RangeNode<float> LimitDrawPlot { get; set; } = new RangeNode<float>(0.2f, 0.05f, 20f);
        [Menu("�p�G�~���{����V�u�@�W�L X ms, �����C", 13, 3000)]
        public RangeNode<int> CriticalTimeForPlugin { get; set; } = new RangeNode<int>(100, 1, 2000);
        #endregion

        #region multithread
        [Menu("�h�u�{", 4000)]
        public EmptyNode EmptyMultithread { get; set; } = new EmptyNode();
        [Menu("�[������h�u�{", 1, 4000)]
        public ToggleNode MultiThreadLoadPlugins { get; set; } = new ToggleNode(false);
        [Menu("��{ �h�u�{", "", 2, 4000)]
        public ToggleNode CoroutineMultiThreading { get; set; } = new ToggleNode(true);
        [Menu("����h�u�{", 3, 4000)]
        public ToggleNode AddedMultiThread { get; set; } = new ToggleNode(false);
        [Menu("�ѪR�h�u�{", 4, 4000)]
        public ToggleNode ParseEntitiesInMultiThread { get; set; } = new ToggleNode(false);
        #endregion

        #region miscellaneous
        [Menu("Miscellaneous", 5000)]
        public EmptyNode EmptyMiscellaneous { get; set; } = new EmptyNode();
        [Menu("Font", 1, 5000)]
        public ListNode Font { get; set; } = new ListNode { Values = new List<string> { "Not found" } };
        [IgnoreMenu] // "Currently not works. Because this option broke calculate how much pixels needs for render."
        public RangeNode<int> FontSize { get; set; } = new RangeNode<int>(13, 7, 36);
        [Menu("Volume", 3, 5000)]
        public RangeNode<int> Volume { get; set; } = new RangeNode<int>(100, 0, 100);
        #endregion
    }
}
