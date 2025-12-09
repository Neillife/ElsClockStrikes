using ElsClockStrikes.Core;
using ElsClockStrikes.Forms;
using Guna.UI.WinForms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace ElsClockStrikes.Tests.Forms
{
    public class FormsCustomizeUtilsTests
    {
        //private readonly ITestOutputHelper _output;

        //public FormsCustomizeUtilsTests(ITestOutputHelper output)
        //{
        //    _output = output;
        //}

        [Theory]
        [InlineData("CustomizeTimeLeftLabelName", FormsConstant.timeLeftLabelBaseName)]
        [InlineData("CustomizeHotKeyLabelName", FormsConstant.hotKeyLabelBaseName)]
        [InlineData("CustomizeMechanicLabelName", FormsConstant.mechanicLabelBaseName)]
        [InlineData("CustomizeComboBoxName", FormsConstant.comboBoxBaseName)]
        [InlineData("CustomizeTextBoxName", FormsConstant.textBoxBaseName)]
        [InlineData("CustomizeButtonName", FormsConstant.buttonBaseName)]
        [InlineData("CustomizeTimerName", FormsConstant.timerBaseName)]
        [InlineData("CustomizeAudioPlayer", FormsConstant.audioPlayerButtonBaseName)]
        [InlineData("CustomizeSettingButton", FormsConstant.settingButtonBaseName)]
        [InlineData("CustomizePanel", FormsConstant.panelBaseName)]
        [InlineData("CustomizeFormInstanceCheckBox", FormsConstant.formInstanceCheckBoxBaseName)]
        public void Should_Return_Prefix_When_String_StartsWith_Prefix(string input, string expectedPrefix)
        {
            var result = FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(input);

            Assert.Equal(expectedPrefix, result);
        }

        [Theory]
        [InlineData("UnknownName")]
        [InlineData("NotMatching123")]
        [InlineData("Test")]
        public void Should_Return_Original_When_No_Prefix_Matched(string input)
        {
            var result = FormsCustomizeUtils.GetRemoveIndexCharOfStrgin(input);

            Assert.Equal(input, result);
        }

        [Theory]
        [InlineData("ABC123", "123")]               // 結尾有數字
        [InlineData("12ABC34", "1234")]             // 混合數字
        [InlineData("A1B2C3", "123")]               // 數字分散
        [InlineData("NoDigitsHere", "")]            // 沒有數字回傳空字串
        [InlineData("000Test999", "000999")]        // 支援前導零
        [InlineData("👍5🔥9", "59")]               // Unicode 也應正常處理
        [InlineData("123", "123")]                  // 全數字
        public void Should_Return_All_Digits_In_Order(string input, string expected)
        {
            var result = FormsCustomizeUtils.GetIndexOfString(input);

            Assert.Equal(expected, result);
        }

        [UIFact]
        public async Task Should_Remove_Controls_With_Matching_Prefix_And_Index()
        {
            await Task.Yield();
            // Arrange
            TabPage tab = new TabPage();
            int oldIndex = FormsConstant.indexForCustomizeName;
            FormsConstant.indexForCustomizeName = 8;
            Label timeLeftLabel = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}1" };
            Label hotKeyLabel = new Label { Name = $"{FormsConstant.hotKeyLabelBaseName}2" };
            Label mechanicLabel = new Label { Name = $"{FormsConstant.mechanicLabelBaseName}3" };
            GunaComboBox comboBox = new GunaComboBox { Name = $"{FormsConstant.comboBoxBaseName}4" };
            GunaLineTextBox textBox = new GunaLineTextBox { Name = $"{FormsConstant.textBoxBaseName}5" };
            GunaButton button = new GunaButton { Name = $"{FormsConstant.buttonBaseName}6" };
            GunaButton settingButton = new GunaButton { Name = $"{FormsConstant.settingButtonBaseName}7" };
            GunaPanel panel = new GunaPanel { Name = $"{FormsConstant.panelBaseName}8" };
            Label ctlNonTarget = new Label { Name = "RandomName123" };
            tab.Controls.Add(timeLeftLabel);
            tab.Controls.Add(hotKeyLabel);
            tab.Controls.Add(mechanicLabel);
            tab.Controls.Add(comboBox);
            tab.Controls.Add(textBox);
            tab.Controls.Add(button);
            tab.Controls.Add(settingButton);
            tab.Controls.Add(panel);
            tab.Controls.Add(ctlNonTarget);

            // Act
            FormsCustomizeUtils.ProcessLoadConfigRemoveComponent(tab);
            FormsConstant.indexForCustomizeName = oldIndex;

            // Assert
            // 應被移除
            Assert.False(tab.Controls.Contains(timeLeftLabel));
            Assert.False(tab.Controls.Contains(hotKeyLabel));
            Assert.False(tab.Controls.Contains(mechanicLabel));
            Assert.False(tab.Controls.Contains(comboBox));
            Assert.False(tab.Controls.Contains(textBox));
            Assert.False(tab.Controls.Contains(button));
            Assert.False(tab.Controls.Contains(settingButton));
            Assert.False(tab.Controls.Contains(panel));

            Assert.True(tab.Controls.Contains(ctlNonTarget));  // prefix 不符合不移除
        }

        [Fact]
        public void Should_Not_Throw_When_No_Controls_To_Remove()
        {
            TabPage tab = new TabPage();
            int oldIndex = FormsConstant.indexForCustomizeName;
            FormsConstant.indexForCustomizeName = 10;
            Label label = new Label { Name = "NotMatchingName" };
            tab.Controls.Add(label);

            // Act
            FormsCustomizeUtils.ProcessLoadConfigRemoveComponent(tab);
            FormsConstant.indexForCustomizeName = oldIndex;

            // Assert
            Assert.True(tab.Controls.Contains(label)); // 應完全沒變
        }

        private (Form form, TabControl tabControl, TabPage tabPage) CreateFormHierarchy()
        {
            Form form = new Form() { Visible = true };
            TabControl tabControl = new TabControl() { Visible = true };
            TabPage tabPage = new TabPage() { Visible = true };

            form.Controls.Add(tabControl);
            tabControl.Controls.Add(tabPage);

            return (form, tabControl, tabPage);
        }

        [Fact]
        public void Should_Move_Labels_From_Form_To_TabPage_When_BackToOriginCheck_True()
        {
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();

            Label label1 = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}1" };
            Label label2 = new Label { Name = $"{FormsConstant.hotKeyLabelBaseName}2" };
            Label label3 = new Label { Name = $"{FormsConstant.mechanicLabelBaseName}3" };

            form.Controls.Add(label1);
            form.Controls.Add(label2);
            form.Controls.Add(label3);

            // Act
            FormsCustomizeUtils.ProcessComponentDisplaySettings(tabPage, true);

            // Assert
            Assert.False(form.Controls.Contains(label1));
            Assert.False(form.Controls.Contains(label2));
            Assert.False(form.Controls.Contains(label3));

            Assert.True(tabPage.Controls.Contains(label1));
            Assert.True(tabPage.Controls.Contains(label2));
            Assert.True(tabPage.Controls.Contains(label3));
        }

        [Fact]
        public void Should_Move_Labels_From_TabPage_To_Form_When_BackToOriginCheck_False()
        {
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();

            Label label1 = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}1" };
            Label label2 = new Label { Name = $"{FormsConstant.hotKeyLabelBaseName}6" };
            Label label3 = new Label { Name = $"{FormsConstant.mechanicLabelBaseName}8" };

            tabPage.Controls.Add(label1);
            tabPage.Controls.Add(label2);
            tabPage.Controls.Add(label3);

            // Act
            FormsCustomizeUtils.ProcessComponentDisplaySettings(tabPage, false);

            // Assert
            Assert.False(tabPage.Controls.Contains(label1));
            Assert.False(tabPage.Controls.Contains(label2));
            Assert.False(tabPage.Controls.Contains(label3));

            Assert.True(form.Controls.Contains(label1));
            Assert.True(form.Controls.Contains(label2));
            Assert.True(form.Controls.Contains(label3));
        }

        [Fact]
        public void Should_Toggle_Labels_In_Form_When_BackToOriginCheck_True()
        {
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();

            Label label1 = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}1", Visible = true };
            Label label2 = new Label { Name = $"{FormsConstant.hotKeyLabelBaseName}3", Visible = true };
            Label nonTarget = new Label { Name = "RandomName123", Visible = true };

            form.Controls.Add(label1);
            form.Controls.Add(label2);
            form.Controls.Add(nonTarget);

            // Act
            FormsCustomizeUtils.ProcessVisible(tabPage, true);

            // Assert true -> false
            Assert.False(label1.Visible);
            Assert.False(label2.Visible);

            // 不符合 prefix 不變
            Assert.True(nonTarget.Visible);
        }

        [Fact]
        public void Should_Toggle_Labels_In_TabPage_When_BackToOriginCheck_False()
        {
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();

            Label label1 = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}2", Visible = false };
            Label label2 = new Label { Name = $"{FormsConstant.hotKeyLabelBaseName}5", Visible = false };
            Label nonTarget = new Label { Name = "OtherLabel55", Visible = false };

            tabPage.Controls.Add(label1);
            tabPage.Controls.Add(label2);
            tabPage.Controls.Add(nonTarget);

            // Act
            FormsCustomizeUtils.ProcessVisible(tabPage, false);

            // Assert false -> true
            Assert.True(label1.Visible);
            Assert.True(label2.Visible);

            // 不符合 prefix 不變
            Assert.False(nonTarget.Visible);
        }

        [Theory]
        [InlineData("A+B+C", new[] { "A", "B", "C" })]
        [InlineData("123+456", new[] { "123", "456" })]
        [InlineData("SingleValue", new[] { "SingleValue" })] // 沒有 '+' 的情況
        [InlineData("", new[] { "" })] // 空字串
        [InlineData("+Leading+Trailing+", new[] { "", "Leading", "Trailing", "" })] // 前後都有 '+'
        public void Should_Split_String_By_Plus(string input, string[] expected)
        {
            // Act
            string[] result = FormsCustomizeUtils.GetSeqSplitStrs(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [UIFact]
        public async Task ProcessSettingText_Should_Update_Label_Text_Correctly()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();

            Label otherLabel = new Label { Name = $"OtherLabel1", Text = "W" };
            Label testLabel = new Label { Name = $"TestLabel1", Text = "123" };
            GunaComboBox otherComboBox = new GunaComboBox { Name = $"OtherComboBox1", Text = "I" };
            GunaLineTextBox otherTextBox = new GunaLineTextBox { Name = $"OtherTextBox1", Text = "246" };
            Label hotKeyLabel = new Label { Name = $"{FormsConstant.hotKeyLabelBaseName}1", Text = "F1" };
            Label timeLeftLabel = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}1", Text = "10" };
            GunaComboBox comboBox = new GunaComboBox { Name = $"{FormsConstant.comboBoxBaseName}1", Text = "A" };
            GunaLineTextBox textBox = new GunaLineTextBox { Name = $"{FormsConstant.textBoxBaseName}1", Text = "777" };

            tabPage.Controls.Add(otherLabel);
            tabPage.Controls.Add(testLabel);
            tabPage.Controls.Add(otherComboBox);
            tabPage.Controls.Add(otherTextBox);
            tabPage.Controls.Add(timeLeftLabel);
            tabPage.Controls.Add(hotKeyLabel);
            tabPage.Controls.Add(comboBox);
            tabPage.Controls.Add(textBox);

            // Act
            FormsCustomizeUtils.ProcessSettingText(tabPage);

            // Assert
            Assert.Equal(hotKeyLabel.Text, comboBox.Text);
            Assert.Equal(timeLeftLabel.Text, textBox.Text);

            Assert.NotEqual(otherLabel.Text, otherComboBox.Text);
            Assert.NotEqual(testLabel.Text, otherTextBox.Text);
        }

        [UIFact]
        public async Task ProcessSettingText_Should_Not_Update_Label_Text()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();

            Label otherLabel1 = new Label { Name = "OtherLabel1", Text = "Z" };
            Label otherLabel2 = new Label { Name = "OtherLabel2", Text = "0" };
            GunaComboBox otherComboBox = new GunaComboBox { Name = "OtherComboBox1", Text = "J" };
            GunaLineTextBox otherTextBox = new GunaLineTextBox { Name = "OtherTextBox1", Text = "123" };

            tabPage.Controls.Add(otherLabel1);
            tabPage.Controls.Add(otherLabel2);
            tabPage.Controls.Add(otherComboBox);
            tabPage.Controls.Add(otherTextBox);

            // Act
            FormsCustomizeUtils.ProcessSettingText(tabPage);

            // Assert
            // other 不符合 prefix Text 不變
            Assert.NotEqual(otherLabel1.Text, otherComboBox.Text);
            Assert.NotEqual(otherLabel2.Text, otherTextBox.Text);
        }

        [Fact]
        public void GetCustomFIPMapByTabPage_Should_Return_Correct_FIP_Dict()
        {
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            string index = "1";
            Label otherLabel = new Label { Name = $"OtherLabel{index}", Text = "T" };
            Label hotKeyLabel = new Label { Name = $"{FormsConstant.hotKeyLabelBaseName}{index}", Text = "F1" };
            Label nameLabel = new Label { Name = $"{FormsConstant.mechanicLabelBaseName}{index}", Text = "Test" };
            Label timeLeftLabel = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}{index}", Text = "10" };

            tabPage.Controls.Add(otherLabel);
            tabPage.Controls.Add(hotKeyLabel);
            tabPage.Controls.Add(nameLabel);
            tabPage.Controls.Add(timeLeftLabel);

            // Act
            Dictionary<string, FormInstanceParameters> result = FormsCustomizeUtils.GetCustomFIPMapByTabPage(tabPage);

            // Assert
            Assert.Same(hotKeyLabel, result[index].keyLabel);
            Assert.Same(nameLabel, result[index].nameLabel);
            Assert.Same(timeLeftLabel, result[index].timeLeftLabel);

            Assert.NotSame(otherLabel, result[index].keyLabel);
            Assert.NotSame(otherLabel, result[index].nameLabel);
            Assert.NotSame(otherLabel, result[index].timeLeftLabel);
        }

        [Fact]
        public void GetCustomFIPMapByTabPage_Should_Return_Empty_FIP_Dict()
        {
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();

            Label hotKeyLabel = new Label { Name = "TestHotkeyLabel", Text = "F1" };
            Label nameLabel = new Label { Name = "TestNameLabel", Text = "Test" };
            Label timeLeftLabel = new Label { Name = "TestTimeLeftLabel", Text = "10" };
            tabPage.Controls.Add(hotKeyLabel);
            tabPage.Controls.Add(nameLabel);
            tabPage.Controls.Add(timeLeftLabel);

            // Act
            Dictionary<string, FormInstanceParameters> result = FormsCustomizeUtils.GetCustomFIPMapByTabPage(tabPage);

            // Assert
            Assert.Empty(result);
        }

        [UIFact]
        public async Task GetFormInstanceCheckBoxByTabPage_Should_Return_Correct_CheckBox_List()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            int oldIndex = FormsConstant.indexForCustomizeName;
            GunaPanel othrtPanel = new GunaPanel { Name = $"OtherPanel" };
            GunaCheckBox othrtCheckBox = new GunaCheckBox { Name = $"OtherCheckBox" };
            GunaPanel panel1 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}1" };
            GunaCheckBox checkBox1 = new GunaCheckBox { Name = $"{FormsConstant.formInstanceCheckBoxBaseName}1" };
            GunaPanel panel2 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}2" };
            GunaCheckBox checkBox2 = new GunaCheckBox { Name = $"{FormsConstant.formInstanceCheckBoxBaseName}2" };
            GunaPanel panel3 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}3" };
            GunaCheckBox checkBox3 = new GunaCheckBox { Name = $"{FormsConstant.formInstanceCheckBoxBaseName}3" };
            
            othrtPanel.Controls.Add(othrtCheckBox);
            panel1.Controls.Add(checkBox1);
            panel2.Controls.Add(checkBox2);
            panel3.Controls.Add(checkBox3);
            tabPage.Controls.Add(othrtPanel);
            tabPage.Controls.Add(panel1);
            tabPage.Controls.Add(panel2);
            tabPage.Controls.Add(panel3);
            FormsConstant.indexForCustomizeName = 3;
            
            // Act
            List<GunaCheckBox> result = FormsCustomizeUtils.GetFormInstanceCheckBoxByTabPage(tabPage);
            FormsConstant.indexForCustomizeName = oldIndex;

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Contains(checkBox1, result);
            Assert.Contains(checkBox2, result);
            Assert.Contains(checkBox3, result);

            // 不應存在
            Assert.DoesNotContain(othrtCheckBox, result);
        }

        [UIFact]
        public async Task GetFormInstanceCheckBoxByTabPage_Should_Return_Empty_CheckBox_List()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            GunaPanel othrtPanel1 = new GunaPanel { Name = $"OtherPanel1" };
            GunaCheckBox othrtCheckBox1 = new GunaCheckBox { Name = $"OtherCheckBox1" };
            GunaPanel othrtPanel2 = new GunaPanel { Name = $"OtherPanel2" };
            GunaCheckBox othrtCheckBox2 = new GunaCheckBox { Name = $"OtherCheckBox2" };
            GunaPanel othrtPanel3 = new GunaPanel { Name = $"OtherPanel3" };
            GunaCheckBox othrtCheckBox3 = new GunaCheckBox { Name = $"OtherCheckBox3" };

            othrtPanel1.Controls.Add(othrtCheckBox1);
            othrtPanel2.Controls.Add(othrtCheckBox2);
            othrtPanel3.Controls.Add(othrtCheckBox3);
            tabPage.Controls.Add(othrtPanel1);
            tabPage.Controls.Add(othrtPanel2);
            tabPage.Controls.Add(othrtPanel3);

            // Act
            List<GunaCheckBox> result = FormsCustomizeUtils.GetFormInstanceCheckBoxByTabPage(tabPage);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetTheSetControlMap_Should_Return_Correct_ControlMap()
        {
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            int oldIndex = FormsConstant.indexForCustomizeName;
            string prefix = FormsConstant.hotKeyLabelBaseName;
            Label otherLabel = new Label { Name = $"OtherLabel4", Text = "T" };
            Label hotKeyLabel1 = new Label { Name = $"{prefix}1", Text = "F1" };
            Label hotKeyLabel2 = new Label { Name = $"{prefix}2", Text = "A" };
            Label hotKeyLabel3 = new Label { Name = $"{prefix}3", Text = "Q" };

            tabPage.Controls.Add(otherLabel);
            tabPage.Controls.Add(hotKeyLabel1);
            tabPage.Controls.Add(hotKeyLabel2);
            tabPage.Controls.Add(hotKeyLabel3);
            FormsConstant.indexForCustomizeName = 3;

            // Act
            Dictionary<string, Label> result = FormsCustomizeUtils.GetTheSetControlMap<Label>(tabPage, prefix);
            FormsConstant.indexForCustomizeName = oldIndex;

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Same(hotKeyLabel1, result["1"]);
            Assert.Same(hotKeyLabel2, result["2"]);
            Assert.Same(hotKeyLabel3, result["3"]);

            Assert.NotSame(otherLabel, result["1"]);
            Assert.NotSame(otherLabel, result["2"]);
            Assert.NotSame(otherLabel, result["3"]);
        }

        [Fact]
        public void GetTheSetControlMap_Should_Return_Empty_ControlMap()
        {
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            string prefix = FormsConstant.hotKeyLabelBaseName;
            Label otherLabel1 = new Label { Name = $"OtherLabel1", Text = "A" };
            Label otherLabel2 = new Label { Name = $"OtherLabel2", Text = "B" };
            Label otherLabel3 = new Label { Name = $"OtherLabel3", Text = "C" };
            Label otherLabel4 = new Label { Name = $"OtherLabel4", Text = "D" };

            tabPage.Controls.Add(otherLabel1);
            tabPage.Controls.Add(otherLabel2);
            tabPage.Controls.Add(otherLabel3);
            tabPage.Controls.Add(otherLabel4);

            // Act
            Dictionary<string, Label> result = FormsCustomizeUtils.GetTheSetControlMap<Label>(tabPage, prefix);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetCustomizeTaskTimerMap_Should_Return_Correct_CustomizeTaskTimerMap()
        {
            // Arrange
            CustomizeTaskTimer taskTimer1 = new CustomizeTaskTimer($"{FormsConstant.timerBaseName}1");
            CustomizeTaskTimer taskTimer2 = new CustomizeTaskTimer($"{FormsConstant.timerBaseName}2");
            CustomizeTaskTimer taskTimer3 = new CustomizeTaskTimer($"OtherTimer");
            CustomizeTaskTimer taskTimer4 = new CustomizeTaskTimer($"OtherTimer4");
            List<CustomizeTaskTimer> taskTimers = new List<CustomizeTaskTimer>
            {
                taskTimer1,
                taskTimer2,
                taskTimer3,
                taskTimer4
            };

            // Act
            Dictionary<string, CustomizeTaskTimer> result = FormsCustomizeUtils.getCustomizeTaskTimerMap(taskTimers);

            // Assert
            Assert.Equal(4, result.Count);
            Assert.Same(taskTimer1, result["1"]);
            Assert.Same(taskTimer2, result["2"]);
            Assert.Same(taskTimer3, result[""]);
            Assert.Same(taskTimer4, result["4"]);
        }

        [Fact]
        public void GetLabelByCustomizeIndex_Should_Return_Correct_Label()
        {
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            string findLabelPerfix = FormsConstant.hotKeyLabelBaseName;
            int findIndex = 2;
            Label hotKeyLabel1 = new Label { Name = $"{findLabelPerfix}1", Text = "F1" };
            Label hotKeyLabel2 = new Label { Name = $"{findLabelPerfix}2", Text = "A" };
            Label timeLeftLabel1 = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}1", Text = "20" };
            Label timeLeftLabel2 = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}2", Text = "50" };

            tabPage.Controls.Add(hotKeyLabel1);
            tabPage.Controls.Add(hotKeyLabel2);
            tabPage.Controls.Add(timeLeftLabel1);
            tabPage.Controls.Add(timeLeftLabel2);

            // Act
            Label result = FormsCustomizeUtils.getLabelByCustomizeIndex(tabPage, findLabelPerfix, findIndex);

            // Assert
            Assert.NotNull(result);
            Assert.Same(hotKeyLabel2, result);
            Assert.NotSame(hotKeyLabel1, result);
            Assert.NotSame(timeLeftLabel1, result);
            Assert.NotSame(timeLeftLabel2, result);
        }

        [Fact]
        public void GetLabelByCustomizeIndex_Should_Return_Null()
        {
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            string findLabelPerfix = FormsConstant.hotKeyLabelBaseName;
            int findIndex = 3;
            Label hotKeyLabel1 = new Label { Name = $"{findLabelPerfix}1", Text = "F1" };
            Label hotKeyLabel2 = new Label { Name = $"{findLabelPerfix}2", Text = "A" };
            Label timeLeftLabel1 = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}1", Text = "20" };
            Label timeLeftLabel2 = new Label { Name = $"{FormsConstant.timeLeftLabelBaseName}2", Text = "50" };

            tabPage.Controls.Add(hotKeyLabel1);
            tabPage.Controls.Add(hotKeyLabel2);
            tabPage.Controls.Add(timeLeftLabel1);
            tabPage.Controls.Add(timeLeftLabel2);

            // Act
            Label result = FormsCustomizeUtils.getLabelByCustomizeIndex(tabPage, findLabelPerfix, findIndex);

            // Assert
            Assert.Null(result);
            Assert.NotSame(hotKeyLabel1, result);
            Assert.NotSame(hotKeyLabel2, result);
            Assert.NotSame(timeLeftLabel1, result);
            Assert.NotSame(timeLeftLabel2, result);
        }

        [UIFact]
        public async Task GetGunaLineTextBoxByCustomizeIndex_Should_Return_Correct_TextBox()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            int findIndex = 1;
            GunaLineTextBox textBox1 = new GunaLineTextBox { Name = $"{FormsConstant.textBoxBaseName}1", Text = "10" };
            GunaLineTextBox textBox2 = new GunaLineTextBox { Name = $"{FormsConstant.textBoxBaseName}2", Text = "20" };
            GunaLineTextBox soundTextBox1 = new GunaLineTextBox { Name = $"{FormsConstant.soundTextBoxBaseName}1", Text = "30" };
            GunaLineTextBox soundTextBox2 = new GunaLineTextBox { Name = $"{FormsConstant.soundTextBoxBaseName}2", Text = "40" };

            tabPage.Controls.Add(textBox1);
            tabPage.Controls.Add(textBox2);
            tabPage.Controls.Add(soundTextBox1);
            tabPage.Controls.Add(soundTextBox2);

            // Act
            GunaLineTextBox result = FormsCustomizeUtils.getGunaLineTextBoxByCustomizeIndex(tabPage, findIndex);

            // Assert
            Assert.NotNull(result);
            Assert.Same(textBox1, result);
            Assert.NotSame(textBox2, result);
            Assert.NotSame(soundTextBox1, result);
            Assert.NotSame(soundTextBox2, result);
        }

        [UIFact]
        public async Task GetGunaLineTextBoxByCustomizeIndex_Should_Return_Null()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            int findIndex = 3;
            GunaLineTextBox textBox1 = new GunaLineTextBox { Name = $"{FormsConstant.textBoxBaseName}1", Text = "10" };
            GunaLineTextBox textBox2 = new GunaLineTextBox { Name = $"{FormsConstant.textBoxBaseName}2", Text = "20" };
            GunaLineTextBox soundTextBox1 = new GunaLineTextBox { Name = $"{FormsConstant.soundTextBoxBaseName}1", Text = "30" };
            GunaLineTextBox soundTextBox2 = new GunaLineTextBox { Name = $"{FormsConstant.soundTextBoxBaseName}2", Text = "40" };

            tabPage.Controls.Add(textBox1);
            tabPage.Controls.Add(textBox2);
            tabPage.Controls.Add(soundTextBox1);
            tabPage.Controls.Add(soundTextBox2);

            // Act
            GunaLineTextBox result = FormsCustomizeUtils.getGunaLineTextBoxByCustomizeIndex(tabPage, findIndex);

            // Assert
            Assert.Null(result);
            Assert.NotSame(textBox1, result);
            Assert.NotSame(textBox2, result);
            Assert.NotSame(soundTextBox1, result);
            Assert.NotSame(soundTextBox2, result);
        }

        [UIFact]
        public async Task GetGunaComboBoxByCustomizeIndex_Should_Return_Correct_ComboBox()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            int findIndex = 4;
            GunaComboBox comboBox1 = new GunaComboBox { Name = $"{FormsConstant.comboBoxBaseName}1", Text = "Q" };
            GunaComboBox comboBox2 = new GunaComboBox { Name = $"{FormsConstant.comboBoxBaseName}2", Text = "W" };
            GunaComboBox comboBox3 = new GunaComboBox { Name = $"{FormsConstant.comboBoxBaseName}3", Text = "E" };
            GunaComboBox comboBox4 = new GunaComboBox { Name = $"{FormsConstant.comboBoxBaseName}4", Text = "R" };

            tabPage.Controls.Add(comboBox1);
            tabPage.Controls.Add(comboBox2);
            tabPage.Controls.Add(comboBox3);
            tabPage.Controls.Add(comboBox4);

            // Act
            GunaComboBox result = FormsCustomizeUtils.getGunaComboBoxByCustomizeIndex(tabPage, findIndex);

            // Assert
            Assert.NotNull(result);
            Assert.Same(comboBox4, result);
            Assert.NotSame(comboBox1, result);
            Assert.NotSame(comboBox2, result);
            Assert.NotSame(comboBox3, result);
        }

        [UIFact]
        public async Task GetGunaComboBoxByCustomizeIndex_Should_Return_Null()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            int findIndex = 9;
            GunaComboBox comboBox1 = new GunaComboBox { Name = $"{FormsConstant.comboBoxBaseName}1", Text = "Q" };
            GunaComboBox comboBox2 = new GunaComboBox { Name = $"{FormsConstant.comboBoxBaseName}2", Text = "W" };
            GunaComboBox comboBox3 = new GunaComboBox { Name = $"{FormsConstant.comboBoxBaseName}3", Text = "E" };
            GunaComboBox comboBox4 = new GunaComboBox { Name = $"{FormsConstant.comboBoxBaseName}4", Text = "R" };

            tabPage.Controls.Add(comboBox1);
            tabPage.Controls.Add(comboBox2);
            tabPage.Controls.Add(comboBox3);
            tabPage.Controls.Add(comboBox4);

            // Act
            GunaComboBox result = FormsCustomizeUtils.getGunaComboBoxByCustomizeIndex(tabPage, findIndex);

            // Assert
            Assert.Null(result);
            Assert.NotSame(comboBox1, result);
            Assert.NotSame(comboBox2, result);
            Assert.NotSame(comboBox3, result);
            Assert.NotSame(comboBox4, result);
        }

        [UIFact]
        public async Task GetSettingButtonByCustomizeIndex_Should_Return_Correct_Button()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            int findIndex = 3;
            GunaButton button1 = new GunaButton { Name = $"{FormsConstant.buttonBaseName}1", Text = "Test" };
            GunaButton button2 = new GunaButton { Name = $"{FormsConstant.audioPlayerButtonBaseName}2", Text = "audioBtn" };
            GunaButton button3 = new GunaButton { Name = $"{FormsConstant.settingButtonBaseName}3", Text = "setting" };
            GunaButton button4 = new GunaButton { Name = $"{FormsConstant.buttonBaseName}4", Text = "OtherFeat" };

            tabPage.Controls.Add(button1);
            tabPage.Controls.Add(button2);
            tabPage.Controls.Add(button3);
            tabPage.Controls.Add(button4);

            // Act
            GunaButton result = FormsCustomizeUtils.getSettingButtonByCustomizeIndex(tabPage, findIndex);

            // Assert
            Assert.NotNull(result);
            Assert.Same(button3, result);
            Assert.NotSame(button1, result);
            Assert.NotSame(button2, result);
            Assert.NotSame(button4, result);
        }

        [UIFact]
        public async Task GetSettingButtonByCustomizeIndex_Should_Return_Null()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            int findIndex = 666;
            GunaButton button1 = new GunaButton { Name = $"{FormsConstant.buttonBaseName}1", Text = "Test" };
            GunaButton button2 = new GunaButton { Name = $"{FormsConstant.audioPlayerButtonBaseName}2", Text = "audioBtn" };
            GunaButton button3 = new GunaButton { Name = $"{FormsConstant.settingButtonBaseName}3", Text = "setting" };
            GunaButton button4 = new GunaButton { Name = $"{FormsConstant.buttonBaseName}4", Text = "OtherFeat" };

            tabPage.Controls.Add(button1);
            tabPage.Controls.Add(button2);
            tabPage.Controls.Add(button3);
            tabPage.Controls.Add(button4);

            // Act
            GunaButton result = FormsCustomizeUtils.getSettingButtonByCustomizeIndex(tabPage, findIndex);

            // Assert
            Assert.Null(result);
            Assert.NotSame(button1, result);
            Assert.NotSame(button2, result);
            Assert.NotSame(button3, result);
            Assert.NotSame(button4, result);
        }

        [UIFact]
        public async Task GetGunaPanelByCustomizeIndex_Should_Return_Correct_Panel()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            int findIndex = 2;
            GunaPanel button1 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}1"};
            GunaPanel button2 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}2"};
            GunaPanel button3 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}3"};
            GunaPanel button4 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}4"};

            tabPage.Controls.Add(button1);
            tabPage.Controls.Add(button2);
            tabPage.Controls.Add(button3);
            tabPage.Controls.Add(button4);

            // Act
            GunaPanel result = FormsCustomizeUtils.getGunaPanelByCustomizeIndex(tabPage, findIndex);

            // Assert
            Assert.NotNull(result);
            Assert.Same(button2, result);
            Assert.NotSame(button1, result);
            Assert.NotSame(button3, result);
            Assert.NotSame(button4, result);
        }

        [UIFact]
        public async Task GetGunaPanelByCustomizeIndex_Should_Return_Null()
        {
            await Task.Yield();
            // Arrange
            var (form, tabControl, tabPage) = CreateFormHierarchy();
            int findIndex = 2468;
            GunaPanel button1 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}1" };
            GunaPanel button2 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}2" };
            GunaPanel button3 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}3" };
            GunaPanel button4 = new GunaPanel { Name = $"{FormsConstant.panelBaseName}4" };

            tabPage.Controls.Add(button1);
            tabPage.Controls.Add(button2);
            tabPage.Controls.Add(button3);
            tabPage.Controls.Add(button4);

            // Act
            GunaPanel result = FormsCustomizeUtils.getGunaPanelByCustomizeIndex(tabPage, findIndex);

            // Assert
            Assert.Null(result);
            Assert.NotSame(button1, result);
            Assert.NotSame(button2, result);
            Assert.NotSame(button3, result);
            Assert.NotSame(button4, result);
        }
    }
}
