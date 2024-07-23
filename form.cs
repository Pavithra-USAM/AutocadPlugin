using System;
using System.Windows.Forms;

namespace AutoCad.Plugin
{
    public class Form : Form
    {
        public Form()
        {
            // Set form properties
            Text = "Hello Form";
            Width = 300;
            Height = 200;

            // Create and add label
            Label label = new Label
            {
                Text = "Press a button:",
                AutoSize = true,
                Location = new System.Drawing.Point(10, 10)
            };
            Controls.Add(label);

            // Create and add buttons
            Button Line = new Button
            {
                Text = "Line",
                Location = new System.Drawing.Point(10, 40)
            };
            Line.Click += Button_Click;
            Controls.Add(Line);

            Button Circle = new Button
            {
                Text = "Circle",
                Location = new System.Drawing.Point(100, 40)
            };
            Circle.Click += Button_Click;
            Controls.Add(Circle);

            Button Arc = new Button
            {
                Text = "Arc",
                Location = new System.Drawing.Point(190, 40)
            };
            Arc.Click += Button_Click;
            Controls.Add(Arc);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                MessageBox.Show($"You clicked {button.Text}");
            }
        }
    }
}
