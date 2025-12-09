using ElsClockStrikes.Core;
using ElsClockStrikes.Forms;
using Guna.UI.WinForms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace ElsClockStrikes.Tests.Forms
{
    public class FormsUtilsTests
    {
        private class TestTimerControl : Control
        {
            private Timer mechanicTimer;

            public TestTimerControl()
            {
                mechanicTimer = new Timer();
                mechanicTimer.Tag = "小荊棘Timer";
            }
        }

        [Fact]
        public void Should_Return_Timer_When_TagMatchesPattern()
        {
            // Arrange
            TestTimerControl testControl = new TestTimerControl();
            ComboBox comboBox1 = new ComboBox { Name = "小荊棘ComboBox" };
            testControl.Controls.Add(comboBox1);

            // Act
            Timer result = FormsUtils.getTimerByNamingPattern(testControl, comboBox1.Name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("小荊棘Timer", result.Tag);
        }

        [Fact]
        public void Should_Return_Null_When_No_TimerMatchesPattern()
        {
            // Arrange
            TestTimerControl testControl = new TestTimerControl();
            ComboBox comboBox1 = new ComboBox { Name = "WrongNameComboBox" };
            testControl.Controls.Add(comboBox1);

            // Act
            Timer result = FormsUtils.getTimerByNamingPattern(testControl, comboBox1.Name);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Should_Return_Label_When_NameMatchesPattern()
        {
            // Arrange
            Panel panel = new Panel();
            ComboBox comboBox1 = new ComboBox { Name = "小荊棘ComboBox" };
            Label label1 = new Label { Name = "小荊棘CDLabel" };
            panel.Controls.Add(comboBox1);
            panel.Controls.Add(label1);

            // Act
            Label result = FormsUtils.getLabelByNamingPattern(panel, comboBox1.Name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(label1, result);
        }

        [Fact]
        public void Should_Return_Null_When_NoLabelMatchesPattern()
        {
            // Arrange
            Panel panel = new Panel();
            ComboBox comboBox1 = new ComboBox { Name = "小荊棘ComboBox" };
            Label label1 = new Label { Name = "WrongCDLabel" };
            panel.Controls.Add(comboBox1);
            panel.Controls.Add(label1);

            // Act
            Label result = FormsUtils.getLabelByNamingPattern(panel, comboBox1.Name);

            // Assert
            Assert.Null(result);
        }

        [UIFact]
        public async Task Should_Return_GunaLineTextBox_By_NamingPattern()
        {
            await Task.Yield(); // 避免 ActiveX / WinForms 初始化問題

            Panel parent = new Panel();

            // 模擬符合 namePattern 的 TextBox 和 ComboBox
            // namePattern = "小荊棘ComboBox"
            // method 會檢查: "小荊棘ComboBox".Substring(0, len-i) + "TextBox"
            ComboBox cbA = new ComboBox { Name = "小荊棘ComboBox" };
            GunaLineTextBox tbA = new GunaLineTextBox { Name = "小荊棘TextBox" };
            ComboBox cbWrong = new ComboBox { Name = "OtherComboBox" };
            GunaLineTextBox tbWrong = new GunaLineTextBox { Name = "OtherTextBox" };
            ComboBox cbShort = new ComboBox { Name = "MechComboBox" };
            GunaLineTextBox tbShort = new GunaLineTextBox { Name = "MechTextBox" };

            parent.Controls.Add(cbA);
            parent.Controls.Add(tbA);
            parent.Controls.Add(cbWrong);
            parent.Controls.Add(tbWrong);
            parent.Controls.Add(cbShort);
            parent.Controls.Add(tbShort);

            GunaLineTextBox result = FormsUtils.getGunaLineTextBoxByNamingPattern(parent, cbA.Name);

            Assert.NotNull(result);
            Assert.Same(tbA, result);
        }

        [UIFact]
        public async Task Should_Return_Null_When_No_Match()
        {
            await Task.Yield();

            Panel parent = new Panel();
            ComboBox cbA = new ComboBox { Name = "RandomComboBox" };
            GunaLineTextBox tbA = new GunaLineTextBox { Name = "Test123TextBox" };
            parent.Controls.Add(cbA);
            parent.Controls.Add(tbA);

            GunaLineTextBox result = FormsUtils.getGunaLineTextBoxByNamingPattern(parent, cbA.Name);

            Assert.Null(result);
        }

        [UIFact]
        public async Task Should_Return_CheckBoxes_By_TipNames127R3()
        {
            await Task.Yield();
            // Arrange
            TabPage tab = new TabPage();
            List<string> tipNames127R3 = FormsConstant.tipNames127R3;

            GunaPanel panelA = new GunaPanel { Name = $"{tipNames127R3[0]}GunaPanel" };
            GunaCheckBox cbA = new GunaCheckBox { Name = $"{tipNames127R3[0]}分離視窗CheckBox" };
            panelA.Controls.Add(cbA);

            GunaPanel panelB = new GunaPanel { Name = $"{tipNames127R3[1]}GunaPanel" };
            GunaCheckBox cbB = new GunaCheckBox { Name = $"{tipNames127R3[1]}分離視窗CheckBox" };
            panelB.Controls.Add(cbB);

            GunaPanel panelC = new GunaPanel { Name = $"{tipNames127R3[2]}GunaPanel" };
            GunaCheckBox cbC = new GunaCheckBox { Name = $"{tipNames127R3[2]}分離視窗CheckBox" };
            panelC.Controls.Add(cbC);

            GunaPanel panelD = new GunaPanel { Name = $"{tipNames127R3[3]}GunaPanel" };
            GunaCheckBox cbD = new GunaCheckBox { Name = $"{tipNames127R3[3]}分離視窗CheckBox" };
            panelD.Controls.Add(cbD);

            tab.Controls.Add(panelA);
            tab.Controls.Add(panelB);
            tab.Controls.Add(panelC);
            tab.Controls.Add(panelD);

            // Act
            List<GunaCheckBox> result = FormsUtils.GetFormInstanceCheckBoxListByMechanicNames(tab, tipNames127R3);

            // Assert
            Assert.Equal(4, result.Count);
            Assert.Same(cbA, result[0]);
            Assert.Same(cbB, result[1]);
            Assert.Same(cbC, result[2]);
            Assert.Same(cbD, result[3]);
        }

        [UIFact]
        public async Task Should_Return_CheckBoxes_By_TipNames156R1()
        {
            await Task.Yield();
            // Arrange
            TabPage tab = new TabPage();
            List<string> tipNames156R1 = FormsConstant.tipNames156R1;

            GunaPanel panelA = new GunaPanel { Name = $"{tipNames156R1[0]}GunaPanel" };
            GunaCheckBox cbA = new GunaCheckBox { Name = $"{tipNames156R1[0]}分離視窗CheckBox" };
            panelA.Controls.Add(cbA);

            GunaPanel panelB = new GunaPanel { Name = $"{tipNames156R1[1]}GunaPanel" };
            GunaCheckBox cbB = new GunaCheckBox { Name = $"{tipNames156R1[1]}分離視窗CheckBox" };
            panelB.Controls.Add(cbB);

            GunaPanel panelC = new GunaPanel { Name = $"{tipNames156R1[2]}GunaPanel" };
            GunaCheckBox cbC = new GunaCheckBox { Name = $"{tipNames156R1[2]}分離視窗CheckBox" };
            panelC.Controls.Add(cbC);

            GunaPanel panelD = new GunaPanel { Name = $"{tipNames156R1[3]}GunaPanel" };
            GunaCheckBox cbD = new GunaCheckBox { Name = $"{tipNames156R1[3]}分離視窗CheckBox" };
            panelD.Controls.Add(cbD);

            tab.Controls.Add(panelA);
            tab.Controls.Add(panelB);
            tab.Controls.Add(panelC);
            tab.Controls.Add(panelD);

            // Act
            List<GunaCheckBox> result = FormsUtils.GetFormInstanceCheckBoxListByMechanicNames(tab, tipNames156R1);

            // Assert
            Assert.Equal(4, result.Count);
            Assert.Same(cbA, result[0]);
            Assert.Same(cbB, result[1]);
            Assert.Same(cbC, result[2]);
            Assert.Same(cbD, result[3]);
        }

        [UIFact]
        public async Task Should_Return_CheckBoxes_By_TipNames156R3()
        {
            await Task.Yield();
            // Arrange
            TabPage tab = new TabPage();
            List<string> tipNames156R3 = FormsConstant.tipNames156R3;

            GunaPanel panelA = new GunaPanel { Name = $"{tipNames156R3[0]}GunaPanel" };
            GunaCheckBox cbA = new GunaCheckBox { Name = $"{tipNames156R3[0]}分離視窗CheckBox" };
            panelA.Controls.Add(cbA);

            GunaPanel panelB = new GunaPanel { Name = $"{tipNames156R3[1]}GunaPanel" };
            GunaCheckBox cbB = new GunaCheckBox { Name = $"{tipNames156R3[1]}分離視窗CheckBox" };
            panelB.Controls.Add(cbB);

            GunaPanel panelC = new GunaPanel { Name = $"{tipNames156R3[2]}GunaPanel" };
            GunaCheckBox cbC = new GunaCheckBox { Name = $"{tipNames156R3[2]}分離視窗CheckBox" };
            panelC.Controls.Add(cbC);

            GunaPanel panelD = new GunaPanel { Name = $"{tipNames156R3[3]}GunaPanel" };
            GunaCheckBox cbD = new GunaCheckBox { Name = $"{tipNames156R3[3]}分離視窗CheckBox" };
            panelD.Controls.Add(cbD);

            tab.Controls.Add(panelA);
            tab.Controls.Add(panelB);
            tab.Controls.Add(panelC);
            tab.Controls.Add(panelD);

            // Act
            List<GunaCheckBox> result = FormsUtils.GetFormInstanceCheckBoxListByMechanicNames(tab, tipNames156R3);

            // Assert
            Assert.Equal(4, result.Count);
            Assert.Same(cbA, result[0]);
            Assert.Same(cbB, result[1]);
            Assert.Same(cbC, result[2]);
            Assert.Same(cbD, result[3]);
        }

        [UIFact]
        public async Task Should_Skip_When_CheckBox_Not_Found()
        {
            await Task.Yield();
            // Arrange
            TabPage tab = new TabPage();

            GunaPanel panelA = new GunaPanel { Name = "EmptyCheckBoxGunaPanel" };
            tab.Controls.Add(panelA);
            List<string> mechanicNames = new List<string> { "EmptyCheckBox" };

            // Act
            List<GunaCheckBox> result = FormsUtils.GetFormInstanceCheckBoxListByMechanicNames(tab, mechanicNames);

            // Assert
            Assert.Empty(result); // 找不到應回傳空 List
        }

        [UIFact]
        public async Task Should_Not_Match_Wrongly_Named_Controls()
        {
            await Task.Yield();
            // Arrange
            TabPage tab = new TabPage();

            GunaPanel wrongPanel = new GunaPanel { Name = "MechanicAWrongPanel" };
            GunaCheckBox wrongCheckBox = new GunaCheckBox { Name = "MechanicAWrongCheckBox" };
            wrongPanel.Controls.Add(wrongCheckBox);
            tab.Controls.Add(wrongPanel);

            List<string> mechanicNames = new List<string> { "MechanicA" };

            // Act
            List<GunaCheckBox> result = FormsUtils.GetFormInstanceCheckBoxListByMechanicNames(tab, mechanicNames);

            // Assert
            Assert.Empty(result); // 名稱不吻合，所以不會加入
        }

        private Control CreateTestParent()
        {
            Panel parent = new Panel();

            parent.Controls.Add(new Label { Name = "小荊棘按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "小荊棘Label", Text = "小荊棘" });
            parent.Controls.Add(new Label { Name = "小荊棘CDLabel", Text = "10" });
            parent.Controls.Add(new Label { Name = "雷射按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "雷射Label", Text = "雷射" });
            parent.Controls.Add(new Label { Name = "雷射CDLabel", Text = "10" });
            parent.Controls.Add(new Label { Name = "荊棘延遲按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "荊棘延遲Label", Text = "荊棘延遲" });
            parent.Controls.Add(new Label { Name = "荊棘延遲CDLabel", Text = "10" });
            parent.Controls.Add(new Label { Name = "控場按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "控場Label", Text = "控場" });
            parent.Controls.Add(new Label { Name = "控場CDLabel", Text = "10" });

            parent.Controls.Add(new Label { Name = "大招按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "大招Label", Text = "大招" });
            parent.Controls.Add(new Label { Name = "大招CDLabel", Text = "10" });
            parent.Controls.Add(new Label { Name = "大刺按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "大刺Label", Text = "大刺" });
            parent.Controls.Add(new Label { Name = "大刺CDLabel", Text = "10" });
            parent.Controls.Add(new Label { Name = "翻桌按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "翻桌Label", Text = "翻桌" });
            parent.Controls.Add(new Label { Name = "翻桌CDLabel", Text = "10" });
            parent.Controls.Add(new Label { Name = "R1156控場按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "R1156控場Label", Text = "R1156控場" });
            parent.Controls.Add(new Label { Name = "R1156控場CDLabel", Text = "10" });

            parent.Controls.Add(new Label { Name = "大黑按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "大黑Label", Text = "大黑" });
            parent.Controls.Add(new Label { Name = "大黑CDLabel", Text = "10" });
            parent.Controls.Add(new Label { Name = "陰陽陣按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "陰陽陣Label", Text = "陰陽陣" });
            parent.Controls.Add(new Label { Name = "陰陽陣CDLabel", Text = "10" });
            parent.Controls.Add(new Label { Name = "三連按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "三連Label", Text = "三連" });
            parent.Controls.Add(new Label { Name = "三連CDLabel", Text = "10" });
            parent.Controls.Add(new Label { Name = "R3156控場按鍵Label", Text = "F1" });
            parent.Controls.Add(new Label { Name = "R3156控場Label", Text = "R3156控場" });
            parent.Controls.Add(new Label { Name = "R3156控場CDLabel", Text = "10" });

            return parent;
        }

        [Fact]
        public void GetFIPMapByMechanicNames_ShouldReturnCorrectTipNames127R3Mapping()
        {
            // Arrange
            Control parent = CreateTestParent();
            List<string> tipNames127R3 = FormsConstant.tipNames127R3;

            // Act
            Dictionary<string, FormInstanceParameters> result = FormsUtils.GetFIPMapByMechanicNames(parent, tipNames127R3);

            // Assert
            Assert.Equal(4, result.Count);
            Assert.NotNull(result[tipNames127R3[0]].keyLabel);
            Assert.NotNull(result[tipNames127R3[0]].nameLabel);
            Assert.NotNull(result[tipNames127R3[0]].timeLeftLabel);
            Assert.Equal($"{tipNames127R3[0]}按鍵Label", result[tipNames127R3[0]].keyLabel.Name);
            Assert.Equal($"{tipNames127R3[0]}Label", result[tipNames127R3[0]].nameLabel.Name);
            Assert.Equal($"{tipNames127R3[0]}CDLabel", result[tipNames127R3[0]].timeLeftLabel.Name);
            Assert.NotNull(result[tipNames127R3[1]].keyLabel);
            Assert.NotNull(result[tipNames127R3[1]].nameLabel);
            Assert.NotNull(result[tipNames127R3[1]].timeLeftLabel);
            Assert.Equal($"{tipNames127R3[1]}按鍵Label", result[tipNames127R3[1]].keyLabel.Name);
            Assert.Equal($"{tipNames127R3[1]}Label", result[tipNames127R3[1]].nameLabel.Name);
            Assert.Equal($"{tipNames127R3[1]}CDLabel", result[tipNames127R3[1]].timeLeftLabel.Name);
            Assert.NotNull(result[tipNames127R3[2]].keyLabel);
            Assert.NotNull(result[tipNames127R3[2]].nameLabel);
            Assert.NotNull(result[tipNames127R3[2]].timeLeftLabel);
            Assert.Equal($"{tipNames127R3[2]}按鍵Label", result[tipNames127R3[2]].keyLabel.Name);
            Assert.Equal($"{tipNames127R3[2]}Label", result[tipNames127R3[2]].nameLabel.Name);
            Assert.Equal($"{tipNames127R3[2]}CDLabel", result[tipNames127R3[2]].timeLeftLabel.Name);
            Assert.NotNull(result[tipNames127R3[3]].keyLabel);
            Assert.NotNull(result[tipNames127R3[3]].nameLabel);
            Assert.NotNull(result[tipNames127R3[3]].timeLeftLabel);
            Assert.Equal($"{tipNames127R3[3]}按鍵Label", result[tipNames127R3[3]].keyLabel.Name);
            Assert.Equal($"{tipNames127R3[3]}Label", result[tipNames127R3[3]].nameLabel.Name);
            Assert.Equal($"{tipNames127R3[3]}CDLabel", result[tipNames127R3[3]].timeLeftLabel.Name);
        }

        [Fact]
        public void GetFIPMapByMechanicNames_ShouldReturnCorrectTipNames156R1Mapping()
        {
            // Arrange
            Control parent = CreateTestParent();
            List<string> tipNames156R1 = FormsConstant.tipNames156R1;

            // Act
            Dictionary<string, FormInstanceParameters> result = FormsUtils.GetFIPMapByMechanicNames(parent, tipNames156R1);

            // Assert
            Assert.Equal(4, result.Count);
            Assert.NotNull(result[tipNames156R1[0]].keyLabel);
            Assert.NotNull(result[tipNames156R1[0]].nameLabel);
            Assert.NotNull(result[tipNames156R1[0]].timeLeftLabel);
            Assert.Equal($"{tipNames156R1[0]}按鍵Label", result[tipNames156R1[0]].keyLabel.Name);
            Assert.Equal($"{tipNames156R1[0]}Label", result[tipNames156R1[0]].nameLabel.Name);
            Assert.Equal($"{tipNames156R1[0]}CDLabel", result[tipNames156R1[0]].timeLeftLabel.Name);
            Assert.NotNull(result[tipNames156R1[1]].keyLabel);
            Assert.NotNull(result[tipNames156R1[1]].nameLabel);
            Assert.NotNull(result[tipNames156R1[1]].timeLeftLabel);
            Assert.Equal($"{tipNames156R1[1]}按鍵Label", result[tipNames156R1[1]].keyLabel.Name);
            Assert.Equal($"{tipNames156R1[1]}Label", result[tipNames156R1[1]].nameLabel.Name);
            Assert.Equal($"{tipNames156R1[1]}CDLabel", result[tipNames156R1[1]].timeLeftLabel.Name);
            Assert.NotNull(result[tipNames156R1[2]].keyLabel);
            Assert.NotNull(result[tipNames156R1[2]].nameLabel);
            Assert.NotNull(result[tipNames156R1[2]].timeLeftLabel);
            Assert.Equal($"{tipNames156R1[2]}按鍵Label", result[tipNames156R1[2]].keyLabel.Name);
            Assert.Equal($"{tipNames156R1[2]}Label", result[tipNames156R1[2]].nameLabel.Name);
            Assert.Equal($"{tipNames156R1[2]}CDLabel", result[tipNames156R1[2]].timeLeftLabel.Name);
            Assert.NotNull(result[tipNames156R1[3]].keyLabel);
            Assert.NotNull(result[tipNames156R1[3]].nameLabel);
            Assert.NotNull(result[tipNames156R1[3]].timeLeftLabel);
            Assert.Equal($"{tipNames156R1[3]}按鍵Label", result[tipNames156R1[3]].keyLabel.Name);
            Assert.Equal($"{tipNames156R1[3]}Label", result[tipNames156R1[3]].nameLabel.Name);
            Assert.Equal($"{tipNames156R1[3]}CDLabel", result[tipNames156R1[3]].timeLeftLabel.Name);
        }

        [Fact]
        public void GetFIPMapByMechanicNames_ShouldReturnCorrectTipNames156R3Mapping()
        {
            // Arrange
            Control parent = CreateTestParent();
            List<string> tipNames156R3 = FormsConstant.tipNames156R3;

            // Act
            Dictionary<string, FormInstanceParameters> result = FormsUtils.GetFIPMapByMechanicNames(parent, tipNames156R3);

            // Assert
            Assert.Equal(4, result.Count);
            Assert.NotNull(result[tipNames156R3[0]].keyLabel);
            Assert.NotNull(result[tipNames156R3[0]].nameLabel);
            Assert.NotNull(result[tipNames156R3[0]].timeLeftLabel);
            Assert.Equal($"{tipNames156R3[0]}按鍵Label", result[tipNames156R3[0]].keyLabel.Name);
            Assert.Equal($"{tipNames156R3[0]}Label", result[tipNames156R3[0]].nameLabel.Name);
            Assert.Equal($"{tipNames156R3[0]}CDLabel", result[tipNames156R3[0]].timeLeftLabel.Name);
            Assert.NotNull(result[tipNames156R3[1]].keyLabel);
            Assert.NotNull(result[tipNames156R3[1]].nameLabel);
            Assert.NotNull(result[tipNames156R3[1]].timeLeftLabel);
            Assert.Equal($"{tipNames156R3[1]}按鍵Label", result[tipNames156R3[1]].keyLabel.Name);
            Assert.Equal($"{tipNames156R3[1]}Label", result[tipNames156R3[1]].nameLabel.Name);
            Assert.Equal($"{tipNames156R3[1]}CDLabel", result[tipNames156R3[1]].timeLeftLabel.Name);
            Assert.NotNull(result[tipNames156R3[2]].keyLabel);
            Assert.NotNull(result[tipNames156R3[2]].nameLabel);
            Assert.NotNull(result[tipNames156R3[2]].timeLeftLabel);
            Assert.Equal($"{tipNames156R3[2]}按鍵Label", result[tipNames156R3[2]].keyLabel.Name);
            Assert.Equal($"{tipNames156R3[2]}Label", result[tipNames156R3[2]].nameLabel.Name);
            Assert.Equal($"{tipNames156R3[2]}CDLabel", result[tipNames156R3[2]].timeLeftLabel.Name);
            Assert.NotNull(result[tipNames156R3[3]].keyLabel);
            Assert.NotNull(result[tipNames156R3[3]].nameLabel);
            Assert.NotNull(result[tipNames156R3[3]].timeLeftLabel);
            Assert.Equal($"{tipNames156R3[3]}按鍵Label", result[tipNames156R3[3]].keyLabel.Name);
            Assert.Equal($"{tipNames156R3[3]}Label", result[tipNames156R3[3]].nameLabel.Name);
            Assert.Equal($"{tipNames156R3[3]}CDLabel", result[tipNames156R3[3]].timeLeftLabel.Name);
        }

        [Theory]
        [InlineData("小荊棘ComboBox", "set小荊棘Time")]
        [InlineData("雷射ComboBox", "set雷射Time")]
        [InlineData("荊棘延遲ComboBox", "set荊棘延遲Time")]
        [InlineData("控場ComboBox", "set控場Time")]
        [InlineData("大招ComboBox", "set大招Time")]
        [InlineData("大刺ComboBox", "set大刺Time")]
        [InlineData("翻桌ComboBox", "set翻桌Time")]
        [InlineData("R1156控場ComboBox", "setR1156控場Time")]
        [InlineData("大黑ComboBox", "set大黑Time")]
        [InlineData("陰陽陣ComboBox", "set陰陽陣Time")]
        [InlineData("三連ComboBox", "set三連Time")]
        [InlineData("R3156控場ComboBox", "setR3156控場Time")]
        public void GetMethodInfoByNamingPattern_ShouldReturnExpected(string input, string expected)
        {
            // Act
            MethodInfo result = FormsUtils.getMethodInfoByNamingPattern(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Name);
        }

        [Theory]
        [InlineData("init127Timer")]
        [InlineData("init156R1Timer")]
        [InlineData("init156R3Timer")]
        public void GetMethodInfoByNamingPattern_NoMatch_ShouldReturnNull(string input)
        {
            // Act
            MethodInfo result = FormsUtils.getMethodInfoByNamingPattern(input);

            // Assert
            Assert.Null(result);
        }

        private class TestForm : Control
        {
            private AudioPlayer testTimeupAudioPlayer = new AudioPlayer("");
            public ComboBox comboBox =  new ComboBox() { Name = "testComboBox" };

            private AudioPlayer notFoundTimeupAudioPlayer = new AudioPlayer("");
            public ComboBox comboBox2 = new ComboBox() { Name = "nonexistentComboBox" };
        }

        [Fact]
        public void GetAudioPlayerFieldByNamingPattern_NotFound_ShouldReturnNull()
        {
            // Arrange
            TestForm form = new TestForm();

            // Act
            AudioPlayer result = FormsUtils.getAudioPlayerFieldByNamingPattern(typeof(TestForm), form, form.comboBox2.Name);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetAudioPlayerFieldByNamingPattern_ShouldReturnCorrectAudioPlayer()
        {
            TestForm form = new TestForm();

            AudioPlayer result = FormsUtils.getAudioPlayerFieldByNamingPattern(typeof(TestForm), form, form.comboBox.Name);

            Assert.NotNull(result);
            Assert.IsType<AudioPlayer>(result);
            string fieldName = typeof(TestForm)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.GetValue(form) == result)
                .Name;
            Assert.Equal("testTimeupAudioPlayer", fieldName);
        }

        [Fact]
        public void GetLabelMaxWidth_ShouldReturnMaxWidthExcludingCopyright()
        {
            Panel parent = new Panel();   //Panel is lite

            parent.Controls.Add(new Label { Width = 50, Text = "A" });
            parent.Controls.Add(new Label { Width = 120, Text = "B" });
            parent.Controls.Add(new Label { Width = 200, Text = FormsConstant.copyrightTag }); // Should be excluded
            parent.Controls.Add(new Label { Width = 80, Text = "C" });

            int result = FormsUtils.GetLabelMaxWidth(parent);

            Assert.Equal(120, result);
        }

        [Fact]
        public void GetLabelMaxWidth_NoLabels_ShouldReturnZero()
        {
            // Arrange
            Panel parent = new Panel();

            // Act
            int result = FormsUtils.GetLabelMaxWidth(parent);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetLabelMaxWidth_OnlyCopyrightLabels_ShouldReturnZero()
        {
            // Arrange
            Panel parent = new Panel();

            parent.Controls.Add(new Label { Width = 150, Text = FormsConstant.copyrightTag });
            parent.Controls.Add(new Label { Width = 180, Text = FormsConstant.copyrightTag });

            // Act
            int result = FormsUtils.GetLabelMaxWidth(parent);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetLabelMaxWidth_ControlsButNoLabels_ShouldReturnZero()
        {
            // Arrange
            Panel parent = new Panel();

            parent.Controls.Add(new Button { Width = 300 }); // non Label
            parent.Controls.Add(new TextBox { Width = 200 });

            // Act
            int result = FormsUtils.GetLabelMaxWidth(parent);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetLabelMaxWidth_MixedControls_ShouldReturnCorrectMax()
        {
            // Arrange
            Panel parent = new Panel();

            parent.Controls.Add(new Button { Width = 300 });             // ignore
            parent.Controls.Add(new Label { Width = 90, Text = "X" });
            parent.Controls.Add(new TextBox { Width = 200 });            // ignore
            parent.Controls.Add(new Label { Width = 150, Text = "Y" });  // return result

            // Act
            int result = FormsUtils.GetLabelMaxWidth(parent);

            // Assert
            Assert.Equal(150, result);
        }

        [Fact]
        public void Should_Not_Handle_When_Key_Is_Digit()
        {
            var e = new KeyPressEventArgs('5');

            FormsUtils.ProcessKeyPress(e);

            Assert.False(e.Handled);
        }

        [Fact]
        public void Should_Not_Handle_When_Key_Is_Backspace()
        {
            var e = new KeyPressEventArgs((char)Keys.Back);

            FormsUtils.ProcessKeyPress(e);

            Assert.False(e.Handled);
        }

        [Fact]
        public void Should_Handle_When_Key_Is_Not_Digit_Or_Backspace()
        {
            var e = new KeyPressEventArgs('A');

            FormsUtils.ProcessKeyPress(e);

            Assert.True(e.Handled);
        }

        [Theory]
        [InlineData("", "100")]
        [InlineData(" ", "100")]
        [InlineData("101", "100")]
        [InlineData("-1", "100")]
        [InlineData("100", "100")]
        [InlineData("50", "50")]
        [InlineData(" 30 ", "30")]
        public void ProcessSoundTextBoxLeaveCore_ShouldReturnExpected(string input, string expected)
        {
            // Act
            string result = FormsUtils.ProcessSoundTextBoxLeaveCore(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("LCtrl", "LC")]
        [InlineData("RCtrl", "RC")]
        [InlineData("LShift", "LShi")]
        [InlineData("RShift", "RShi")]
        [InlineData("LCtrl+LShift", "LC+LShi")]
        [InlineData("RCtrl+RShift", "RC+RShi")]
        [InlineData("LCtrl+RShift+主鍵盤0", "LC+RShi+主0")]
        [InlineData("RCtrl+LShift+小鍵盤9", "RC+LShi+小9")]
        [InlineData("主鍵盤0", "主0")]    // 移除「鍵盤」
        [InlineData("小鍵盤9", "小9")]    // 移除「鍵盤」
        [InlineData("A", "A")]            // 無需替換
        [InlineData("", "")]              // 空字串
        public void ProcessLayoutString_ShouldReturnExpectedString(string input, string expected)
        {
            // Act
            string result = FormsUtils.ProcessLayoutString(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [UIFact]
        public async Task ProcessSettingBtnClick_Should_Open_When_Panel_Was_Closed()
        {
            await Task.Yield();

            // Arrange
            Panel panel = new Panel { Visible = false };
            GunaButton button = new GunaButton();

            // Act
            FormsUtils.ProcessSettingBtnClick(panel, button);

            // Assert
            Assert.True(panel.Visible);
            Assert.Equal(Color.FromArgb(44, 149, 180), button.BaseColor);
            Assert.Equal(Color.FromArgb(20, 120, 170), button.OnHoverBaseColor);
        }

        [UIFact]
        public async Task ProcessSettingBtnClick_Should_Close_When_Panel_Was_Open()
        {
            await Task.Yield();

            // Arrange
            Panel panel = new Panel { Visible = true };
            GunaButton button = new GunaButton();

            // Act
            FormsUtils.ProcessSettingBtnClick(panel, button);

            // Assert
            Assert.False(panel.Visible);
            Assert.Equal(Color.FromArgb(143, 138, 149), button.BaseColor);
            Assert.Equal(Color.FromArgb(120, 120, 120), button.OnHoverBaseColor);
        }

        [Theory]
        [InlineData("A", HotKeySet.KeySet.A)]                // Enum 可解析
        [InlineData("F1", HotKeySet.KeySet.F1)]              // Enum 可解析
        [InlineData("↑", HotKeySet.KeySet.Up)]              // 箭頭符號
        [InlineData("↓", HotKeySet.KeySet.Down)]            // 箭頭符號
        [InlineData("←", HotKeySet.KeySet.Left)]            // 箭頭符號
        [InlineData("→", HotKeySet.KeySet.Right)]           // 箭頭符號
        [InlineData("InvalidKey", HotKeySet.KeySet.None)]    // 既不是 Enum 也不是箭頭
        [InlineData("", HotKeySet.KeySet.None)]              // 空字串
        [InlineData(null, HotKeySet.KeySet.None)]            // null
        public void TryParseHotKeySet_ShouldReturnExpectedKeySet(string input, HotKeySet.KeySet expected)
        {
            // Act
            HotKeySet.KeySet result = FormsUtils.TryParseHotKeySet(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetHotKeySetStrings_ShouldReturn_AllKeysExceptNone()
        {
            List<string> keys = FormsUtils.GetHotKeySetStrings();

            Assert.Contains("↑", keys);
            Assert.Contains("↓", keys);
            Assert.DoesNotContain("None", keys);
        }

        [Theory]
        [InlineData(HotKeySet.KeySet.Up, "↑")]
        [InlineData(HotKeySet.KeySet.Down, "↓")]
        [InlineData(HotKeySet.KeySet.Left, "←")]
        [InlineData(HotKeySet.KeySet.Right, "→")]
        public void ArrowKeyToSymbol_ShouldReturn_CorrectArrowSymbol(HotKeySet.KeySet key, string expectedSymbol)
        {
            string result = FormsUtils.ArrowKeyToSymbol(key);

            Assert.Equal(expectedSymbol, result);
        }

        [Theory]
        [InlineData(HotKeySet.KeySet.A, "A")]
        [InlineData(HotKeySet.KeySet.F1, "F1")]
        [InlineData(HotKeySet.KeySet.主鍵盤0, "主鍵盤0")]
        [InlineData(HotKeySet.KeySet.小鍵盤5, "小鍵盤5")]
        public void ArrowKeyToSymbol_ShouldReturn_KeyName_ForNonArrowKeys(HotKeySet.KeySet key, string expectedText)
        {
            string result = FormsUtils.ArrowKeyToSymbol(key);

            Assert.Equal(expectedText, result);
        }

        [Theory]
        [InlineData("↑", HotKeySet.KeySet.Up)]
        [InlineData("↓", HotKeySet.KeySet.Down)]
        [InlineData("←", HotKeySet.KeySet.Left)]
        [InlineData("→", HotKeySet.KeySet.Right)]
        [InlineData("A", HotKeySet.KeySet.None)]
        [InlineData("", HotKeySet.KeySet.None)]
        [InlineData(null, HotKeySet.KeySet.None)]
        public void ArrowKeySymbolToHotKeySet_ShouldReturnExpectedKeySet(string input, HotKeySet.KeySet expected)
        {
            HotKeySet.KeySet result = FormsUtils.ArrowKeySymbolToHotKeySet(input);

            Assert.Equal(expected, result);
        }

    }
}
