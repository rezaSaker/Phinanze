using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phinanze.Views
{
    public class CustomViewProps
    {
        private static Dictionary<TextBox, string> placeholderTextBoxes = new Dictionary<TextBox, string>();
        public static void Placeholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;
            textBox.GotFocus += RemovePlaceholder;
            textBox.LostFocus += AddPlaceholder;
            placeholderTextBoxes.Add(textBox, placeholderText);
        }

        public static bool HasPlaceholder(TextBox textBox)
        {
            return placeholderTextBoxes.ContainsKey(textBox) && placeholderTextBoxes[textBox] == textBox.Text && textBox.ForeColor == Color.Gray;
        }

        private static void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if(textBox != null && placeholderTextBoxes[textBox] != null && placeholderTextBoxes[textBox] == textBox.Text)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black;
            }
        }

        private static void AddPlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null && placeholderTextBoxes[textBox] != null && textBox.Text.IsNullOrEmpty())
            {
                textBox.Text = placeholderTextBoxes[textBox];
                textBox.ForeColor = Color.Gray;
            }
        }
    }
}
