using System;
using System.Reflection;
using System.Windows.Forms;
using GuiLabs.Undo;

namespace WinFormsSample
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Our action manager who takes care of all Undo/Redo stuff
        /// </summary>
        ActionManager actionManager = new ActionManager();

        /// <summary>
        /// Our business objects (domain model)
        /// </summary>
        Person joe = new Person();

        public Form1()
        {
            InitializeComponent();
            // two way updating: when joe's properties change, update the UI
            joe.NameChanged += joe_NameChanged;
            joe.AgeChanged += joe_AgeChanged;
            UpdateUndoRedoButtons();
        }

        /// <summary>
        /// Update the UI when the object model changes, but disable the textbox textchanged event to prevent recursion
        /// </summary>
        void joe_AgeChanged()
        {
            reentrancyGuard = true;
            txtAge.Text = joe.Age.ToString();
            reentrancyGuard = false;
        }

        /// <summary>
        /// Update the UI when the object model changes, but disable the textbox textchanged event to prevent recursion
        /// </summary>
        void joe_NameChanged()
        {
            reentrancyGuard = true;
            txtName.Text = joe.Name;
            reentrancyGuard = false;
        }

        /// <summary>
        /// set to true when the UI was updated programmatically and not by user
        /// </summary>
        bool reentrancyGuard = false;

        void txtName_TextChanged(object sender, EventArgs e)
        {
            SetProperty("Name", txtName.Text);
        }

        void txtAge_TextChanged(object sender, EventArgs e)
        {
            int age = 0;
            if (int.TryParse(txtAge.Text, out age))
            {
                SetProperty("Age", age);
            }
        }

        /// <summary>
        /// API to update the object model from the UI
        /// Creates an action and registers it with the action manager
        /// This is the interesting part of the demo
        /// </summary>
        void SetProperty(string propertyName, object propertyValue)
        {
            if (reentrancyGuard)
            {
                return;
            }
            SetPropertyAction action = new SetPropertyAction(joe, propertyName, propertyValue);
            actionManager.RecordAction(action);
            UpdateUndoRedoButtons();
        }

        void btnUndo_Click(object sender, EventArgs e)
        {
            actionManager.Undo();
            UpdateUndoRedoButtons();
        }

        void btnRedo_Click(object sender, EventArgs e)
        {
            actionManager.Redo();
            UpdateUndoRedoButtons();
        }

        void UpdateUndoRedoButtons()
        {
            btnUndo.Enabled = actionManager.CanUndo;
            btnRedo.Enabled = actionManager.CanRedo;
        }

        /// <summary>
        /// Demonstrates transactions - whatever happens inside the using statement
        /// is considered a single action
        /// </summary>
        void btnSetMany_Click(object sender, EventArgs e)
        {
            using (Transaction.Create(actionManager))
            {
                SetProperty("Name", "Joe");
                SetProperty("Age", 30);
            }
            UpdateUndoRedoButtons();
        }
    }

    /// <summary>
    /// Domain model object, raises events on property change
    /// </summary>
    public class Person
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                if (NameChanged != null)
                {
                    NameChanged();
                }
            }
        }

        int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                if (AgeChanged != null)
                {
                    AgeChanged();
                }
            }
        }

        public event Action NameChanged;
        public event Action AgeChanged;
    }
}
