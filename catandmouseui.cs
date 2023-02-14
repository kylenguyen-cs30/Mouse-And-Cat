// Name : Hoang Nguyen
// Email :
// Application: 

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class CatAndMouseUI : Form
{
    // UI Size
    private static int formheight = 1200;
    private static int formwidth = 200 + formheight;
    private Size ui_size = new Size(formwidth, formheight);


    //Labels
    //Position parameter
    private const int horizontal_displacement_label = 100;
    private const int vertical_displacement_label = 30;
    private const int label_text_size = 8;

    //Title
    private Label title_label = new Label();
    private Size title_label_size = new Size(600, 100);
    private Point title_label_location = new Point(400,10);
    private Font title_label_font = new Font("Arial", 30 ,FontStyle.Bold);
    private Color title_label_color =  Color.FromArgb(239,245,245);
    //Enter Speed Red Ball
    private Label enter_speed_red_ball = new Label();
    private Size enter_speed_red_ball_size = new Size(170,20);
    private Point enter_speed_red_ball_location = new Point(horizontal_displacement_label, vertical_displacement_label);
    private Font enter_speed_red_ball_font = new Font("Arial", label_text_size ,FontStyle.Bold);
    //Enter Speed Blue Ball
    private Label enter_speed_blue_ball = new Label();
    private Size enter_speed_blue_ball_size = new Size(170,20);
    private Point enter_speed_blue_ball_location = new Point(horizontal_displacement_label + 200, vertical_displacement_label);
    private Font enter_speed_blue_ball_font = new Font("Arial", label_text_size ,FontStyle.Bold);
    //Red Ball Location (Cat Location)
    private Label red_ball_position = new Label();
    private Size red_ball_position_size = new Size(170,20);
    private Point red_ball_position_location = new Point(horizontal_displacement_label + 400, vertical_displacement_label);
    private Font red_ball_position_font = new Font("Arial", label_text_size ,FontStyle.Bold);
    //Blue Ball Location (Mouse location)
    private Label blue_ball_position = new Label();
    private Size blue_ball_position_size = new Size(170,20);
    private Point blue_ball_position_location = new Point(horizontal_displacement_label + 600, vertical_displacement_label);
    private Font blue_ball_position_font = new Font("Arial", label_text_size ,FontStyle.Bold);
    //Distance between
    private Label distance_between = new Label();
    private Size distance_between_size = new Size(170,20);
    private Point distance_between_location = new Point(horizontal_displacement_label + 800, vertical_displacement_label);
    private Font distance_between_font = new Font("Arial" , label_text_size , FontStyle.Bold);

    // Button
    //Start Button
    private Button start_button = new Button();
    private Size start_button_size = new Size(70,50);
    private Color start_button_color = Color.FromArgb(229,217,182);
    private Point start_button_location = new Point(10,30);
    private Font start_button_font = new Font("Arial", 10 ,FontStyle.Bold);
    //Quit Button
    private Button quit_button = new Button();
    private Size quit_button_size = new Size(50,50);
    private Color quit_button_color = Color.FromArgb(233 , 119 , 119);
    private Point quit_button_location = new Point(1300, 30);
    private Font quit_button_font = new Font("Arial", 10 ,FontStyle.Bold);
    
    
    //Text Fields
    // Constant Parameter
    private const int horizontal_displacement_textfield = 100;
    private const int vertical_displacement_textfield = 50;
    //Enter Speed Red Ball Text Field
    private TextBox enter_speed_red_ball_box = new TextBox();
    private Size enter_speed_red_ball_box_size = new Size(100, 20);
    private Font enter_speed_red_ball_box_font = new Font("Arial", 10 ,FontStyle.Bold);
    private Point enter_speed_red_ball_box_location = new Point(horizontal_displacement_textfield , vertical_displacement_textfield);
    //Enter Speed Blue Ball Text Field
    private TextBox enter_speed_blue_ball_box = new TextBox();
    private Size enter_speed_blue_ball_box_size = new Size(100, 20);
    private Font enter_speed_blue_ball_box_font = new Font("Arial", 10 ,FontStyle.Bold);
    private Point enter_speed_blue_ball_box_location = new Point(horizontal_displacement_textfield + 200, vertical_displacement_textfield);
    //Red Ball Position box (Cat location)
    private TextBox red_ball_position_box = new TextBox();
    private Size red_ball_position_box_size = new Size(100,20);
    private Font red_ball_position_box_font = new Font("Arial" , 10, FontStyle.Bold);
    private Point red_ball_position_box_location = new Point(horizontal_displacement_textfield + 400, vertical_displacement_textfield);
    //Blue Ball Position box (Mouse Location)
    private TextBox blue_ball_position_box = new TextBox();
    private Size blue_ball_position_box_size = new Size(100, 20);
    private Font blue_ball_position_box_font = new Font("Arial", 10, FontStyle.Bold);
    private Point blue_ball_position_box_location = new Point(horizontal_displacement_textfield + 600, vertical_displacement_textfield);
    //Distance Between textbox
    private TextBox distance_between_box = new TextBox();
    private Size distance_between_box_size = new Size(100,20);
    private Font distance_between_box_font = new Font("Arial" , 10, FontStyle.Bold);
    private Point distance_between_box_location = new Point(horizontal_displacement_label + 800, vertical_displacement_textfield);
    // Panels
    //position parameter
    private const int panel_width = 1400;
    private const int graphic_panel_height = 850;
    private const int control_panel_height = 200;
    private const int header_panel_height = 150;
    //Header Panel
    private Panel header_panel = new Panel();
    private Size header_panel_size = new Size(panel_width, header_panel_height);         
    private Point header_panel_location = new Point(0,0);
    private Color header_panel_color = Color.FromArgb(239,245,245);
    //Control Panel
    private Panel control_panel = new Panel();
    private Size control_panel_size = new Size(panel_width , control_panel_height);
    private Point control_panel_location = new Point(0,header_panel_height + graphic_panel_height);
    private Color control_panel_color = Color.FromArgb(214,228,229);
    //Graphic Panel
    private Graphicpanel graphic_panel = new Graphicpanel();
    private Size graphic_panel_size = new Size(panel_width, graphic_panel_height);
    private Point graphic_panel_location = new Point(0, header_panel_height);
    private Color graphic_panel_color = Color.FromArgb(229,217,182);
    //Clock
    //Refresh Rate Clock
    private const double refresh_rate_clock_speed = 32.8;
    private int refresh_rate_interval = (int)System.Math.Round(1000.0 / refresh_rate_clock_speed);
    private static System.Timers.Timer refresh_rate_clock = new System.Timers.Timer();
    //Cat and mouse clock
    private const double cat_and_mouse_clock_speed = 24.0;
    private int cat_and_mouse_interval = (int)System.Math.Round(1000.0 / cat_and_mouse_clock_speed);
    private static System.Timers.Timer cat_and_mouse_clock = new System.Timers.Timer();
    //Program State
    private enum Program_State{Executing, Waiting_to_terminate ,Game_over};
    private Program_State current_status = Program_State.Executing;

    //Paramaters
    //Coordinates of first ball
    private static int center_first_ball_x = formwidth / 3;
    private static int center_first_ball_y = formheight / 2;
    //Coordinates of second ball
    private static int center_second_ball_x = (formwidth * 2) / 3;
    private static int center_second_ball_y = formheight / 2;
    //Ball size 
    private static int ball_size = 80; 
    //Speed of the ball
    private static double first_ball_per_tic = 0.0;
    private static double second_ball_per_tic = 0.0;
    //Direction variable for the first ball
    private static double delta_x_first_ball = 0.0;
    private static double delta_y_first_ball = 0.0;
    //Direction variable for the second ball
    private static double delta_x_second_ball = 0.0;
    private static double delta_y_second_ball = 0.0;
    //Brush
    private static SolidBrush red_brush = new SolidBrush(Color.Red);
    private static SolidBrush blue_brush = new SolidBrush(Color.Blue);

    //Logical Direction
    DirectionLogic direction_generator = new DirectionLogic();
    //distance checking variables
    private static double dist_check = 0.0;
    private static double x = 0.0;
    private static double y = 0.0;
    private static double result = 0.0;
    //Direction Variables 
    private static double first_ball_angle_radians = 0.0;
    private static double second_ball_angle_radians = 0.0;

    //Turning Angle
    private const double turning_angle = Math.PI/12.0;
    
     







    // Constructor
    public CatAndMouseUI()
    {

        //Main Frame
        Text = "Cat and Mouse";
        Size = new Size(100,100);
        MaximumSize = ui_size;
        MinimumSize = ui_size;

        //Labels
        //Title Label
        title_label.Size = title_label_size;
        title_label.Font = title_label_font;
        title_label.Location = title_label_location;
        title_label.BackColor = title_label_color;
        title_label.Text = "Collide ball by Kyle Nguyen";
        //Enter speed red ball
        enter_speed_red_ball.Size = enter_speed_red_ball_size;
        enter_speed_red_ball.Font = enter_speed_red_ball_font;
        enter_speed_red_ball.Location = enter_speed_red_ball_location;
        enter_speed_red_ball.Text = "Enter speed red ball";
        //Enter speed blue balls
        enter_speed_blue_ball.Size = enter_speed_blue_ball_size;
        enter_speed_blue_ball.Font = enter_speed_blue_ball_font;
        enter_speed_blue_ball.Location = enter_speed_blue_ball_location;
        enter_speed_blue_ball.Text = "Enter speed blue ball";
        //Blue Ball location
        blue_ball_position.Size = blue_ball_position_size;
        blue_ball_position.Font = blue_ball_position_font;
        blue_ball_position.Location = blue_ball_position_location;
        blue_ball_position.Text = "Blue Ball Location";
        //Red Ball location
        red_ball_position.Size = red_ball_position_size;
        red_ball_position.Font = red_ball_position_font;
        red_ball_position.Location = red_ball_position_location;
        red_ball_position.Text = "Red Ball Location";
        //distance label
        distance_between.Size = distance_between_size;
        distance_between.Font = distance_between_font;
        distance_between.Location = distance_between_location;
        distance_between.Text = "Distance Between";

        //Buttons
        //Start Button
        start_button.Size = start_button_size;
        start_button.Font = start_button_font;
        start_button.BackColor = start_button_color;
        start_button.Location = start_button_location;
        start_button.Text = "Start";
        start_button.Click += new EventHandler(start);
        //Quit Button
        quit_button.Size = quit_button_size;
        quit_button.Font = quit_button_font;
        quit_button.BackColor = quit_button_color;
        quit_button.Location = quit_button_location;
        quit_button.Text = "Quit";
        quit_button.Click += new EventHandler(close);

        //Text Fields
        //Enter speed red ball box
        enter_speed_red_ball_box.Size = enter_speed_red_ball_box_size;
        enter_speed_red_ball_box.Font = enter_speed_red_ball_box_font;
        enter_speed_red_ball_box.Location = enter_speed_red_ball_box_location;
        //Enter speed blue ball box
        enter_speed_blue_ball_box.Size = enter_speed_blue_ball_box_size;
        enter_speed_blue_ball_box.Font = enter_speed_blue_ball_box_font;
        enter_speed_blue_ball_box.Location = enter_speed_blue_ball_box_location;
        //Red Ball Position Box
        red_ball_position_box.Size = red_ball_position_box_size;
        red_ball_position_box.Font = red_ball_position_box_font;
        red_ball_position_box.Location = red_ball_position_box_location;
        red_ball_position_box.ReadOnly = true;
        //Blue Ball Position Box
        blue_ball_position_box.Size = blue_ball_position_box_size;
        blue_ball_position_box.Font = blue_ball_position_box_font;
        blue_ball_position_box.Location = blue_ball_position_box_location;
        blue_ball_position_box.ReadOnly = true;
        //Distance Text Field
        distance_between_box.Size = distance_between_box_size;
        distance_between_box.Font = distance_between_box_font;
        distance_between_box.Location = distance_between_box_location;
        distance_between_box.ReadOnly = true;

        // Panels
        //Header Panel
        header_panel.Size = header_panel_size;
        header_panel.BackColor = header_panel_color;
        header_panel.Location = header_panel_location; 
        //Control Panel
        control_panel.Size = control_panel_size;
        control_panel.BackColor = control_panel_color;
        control_panel.Location = control_panel_location;
        //Graphic Panel
        graphic_panel.Size = graphic_panel_size;
        graphic_panel.BackColor = graphic_panel_color;
        graphic_panel.Location = graphic_panel_location;
        //Content allignment
        title_label.TextAlign = ContentAlignment.MiddleCenter;
        enter_speed_red_ball.TextAlign = ContentAlignment.MiddleLeft;
        enter_speed_blue_ball.TextAlign = ContentAlignment.MiddleLeft;
        red_ball_position.TextAlign = ContentAlignment.MiddleLeft;
        blue_ball_position.TextAlign = ContentAlignment.MiddleLeft;
        //Add Controls
        Controls.Add(quit_button);
        Controls.Add(start_button);
        Controls.Add(title_label);
        Controls.Add(enter_speed_red_ball);
        Controls.Add(enter_speed_blue_ball);
        Controls.Add(enter_speed_red_ball_box);
        Controls.Add(enter_speed_blue_ball_box);
        Controls.Add(red_ball_position);
        Controls.Add(blue_ball_position);
        Controls.Add(red_ball_position_box);
        Controls.Add(blue_ball_position_box);
        Controls.Add(enter_speed_red_ball_box);
        Controls.Add(enter_speed_blue_ball_box);
        Controls.Add(distance_between);
        Controls.Add(distance_between_box);
        //Add Controls to Panels
        Controls.Add(header_panel);
        Controls.Add(graphic_panel);
        Controls.Add(control_panel);
        //Control Panel
        control_panel.Controls.Add(start_button);
        control_panel.Controls.Add(quit_button);
        control_panel.Controls.Add(enter_speed_red_ball);
        control_panel.Controls.Add(enter_speed_blue_ball);
        control_panel.Controls.Add(red_ball_position);
        control_panel.Controls.Add(blue_ball_position);
        control_panel.Controls.Add(enter_speed_red_ball_box);
        control_panel.Controls.Add(enter_speed_blue_ball_box);
        control_panel.Controls.Add(red_ball_position);
        control_panel.Controls.Add(blue_ball_position);
        control_panel.Controls.Add(red_ball_position_box);
        control_panel.Controls.Add(blue_ball_position_box);
        control_panel.Controls.Add(distance_between);
        control_panel.Controls.Add(distance_between_box);
        //Cat and mouse clock
        cat_and_mouse_clock.Enabled = false;
        cat_and_mouse_clock.Interval = cat_and_mouse_interval;
        cat_and_mouse_clock.Elapsed += new ElapsedEventHandler(update);

        //Refresh rate Clock
        refresh_rate_clock.Enabled = false;
        refresh_rate_clock.Interval = refresh_rate_interval;
        refresh_rate_clock.Elapsed += new ElapsedEventHandler(refresh);

        //center of the screen
        CenterToScreen();


    }

    //refresh rate
    protected void refresh(System.Object sender, EventArgs e)
    {
        graphic_panel.Invalidate();
    }
    //Close Program
    protected void close(System.Object sender, EventArgs e)
    {
        System.Console.WriteLine("Thank you for using my program");
        Close();
    }
  
  
    //start function
    //initialize everything
    protected void start(System.Object sender, EventArgs e)
    {
        try
        {
            if((enter_speed_red_ball_box ?? enter_speed_blue_ball_box) != null)
            {
                graphic_panel.Focus();
                //getting speed for both balls
                first_ball_per_tic = float.Parse(enter_speed_red_ball_box.Text);    //setting speed for the first ball
                second_ball_per_tic = float.Parse(enter_speed_blue_ball_box.Text);

                //Direction of the first ball
                first_ball_angle_radians = direction_generator.get_random_direction();
                delta_x_first_ball = first_ball_per_tic  * System.Math.Cos(first_ball_angle_radians);
                delta_y_first_ball = first_ball_per_tic * System.Math.Sin(first_ball_angle_radians);

                //Direction of the second ball
                second_ball_angle_radians = direction_generator.get_random_direction();
                delta_x_second_ball = second_ball_per_tic * System.Math.Cos(second_ball_angle_radians);
                delta_y_second_ball = second_ball_per_tic * System.Math.Sin(second_ball_angle_radians);
                

            }
        }
        catch (System.Exception)
        {
            //No input
            //Bad Input
            System.Console.WriteLine("ERROR: Please enter input again.");

            
        }

        //Program Status
        //current_status will let the user know at which state is the program now
        switch (current_status)
        {
            
            case Program_State.Executing:
            //set visible for both balls to True
            //start the clock
            //set text of button from Start to Pause
            start_button.Text = "Pause";
            refresh_rate_clock.Enabled = true;
            cat_and_mouse_clock.Enabled = true;
            current_status = Program_State.Waiting_to_terminate; //set the enum for the next time the user hit the start button.
            break;

            case Program_State.Waiting_to_terminate:
            //pause all the clock
            //set text from "Pause" to "Resume"
            start_button.Text = "Resume";
            refresh_rate_clock.Enabled = false;
            cat_and_mouse_clock.Enabled = false;
            current_status = Program_State.Executing;   //second behavior when the user the start button agian. 
            break;

            case Program_State.Game_over:
            start_button.Text = "Start";
            cat_and_mouse_clock.Enabled = false;
            refresh_rate_clock.Enabled = false;
            break;


        }
    }//End of start function 

    //Distance Function
    // protected static double distance_calculation(double ballone_center_x, double ballone_center_y, double balltwo_center_x, double balltwo_center_y)
    // {
    //     x = ballone_center_x - balltwo_center_x;
    //     y = ballone_center_y - balltwo_center_y;
    //     result = Math.Sqrt(x*x + y*y);
    //     return result;
    // }





    //Update Function
    protected void update(System.Object sender, EventArgs e)
    {
        // update first ball direction 
        center_first_ball_x += (int)delta_x_first_ball;
        center_first_ball_y += (int)delta_y_first_ball;

        // update second ball direction
        center_second_ball_x += (int)delta_x_second_ball;
        center_second_ball_y += (int)delta_y_second_ball;
        //Collide Ball Effect
        //if two balls collide each other, the color will temporary change.
        //when the ball is no longer in contact, the colors will be reverted back 
        //to the orginal color
        //dist_check = distance_calculation(center_first_ball_x, center_second_ball_x, center_second_ball_x, center_second_ball_y);

        x = center_first_ball_x - center_second_ball_x;
        y = center_first_ball_y - center_second_ball_y;
        result = Math.Sqrt(x*x + y*y);

        if(result <= ball_size)
        {
            //Announcement
            System.Console.WriteLine("Game over. Thank you for playing");
           
            //reset position
            center_first_ball_x = formwidth / 3;
            center_first_ball_y = formheight / 2;
            center_second_ball_x = (formwidth * 2) / 3;
            center_second_ball_y = formheight / 2;
            //set Start button text from Pause to start
            start_button.Text = "Start";
            //current status program
            current_status = Program_State.Executing;
            Invalidate();
            //Stop the game and reset everything 
            cat_and_mouse_clock.Enabled = false;
            refresh_rate_clock.Enabled = false;
         
        }

        //first ball bounce if it hit border
        if (center_first_ball_x <= 0 || (center_first_ball_x + ball_size) > formwidth) // first ball hit at the side bar 
        {
            delta_x_first_ball = -delta_x_first_ball;
        }
        if(center_first_ball_y <= 0 || (center_first_ball_y + ball_size) > graphic_panel_height) // first ball hit at the top and bottom bar
        {
            delta_y_first_ball = -delta_y_first_ball;
        }
        //bounce effect for second ball
        if(center_second_ball_x <= 0 || (center_second_ball_x + ball_size) > formwidth) // second ball hit at the side bar
        {
            delta_x_second_ball = -delta_x_second_ball;
        }
        if(center_second_ball_y <= 0 || (center_second_ball_y + ball_size) > graphic_panel_height) // second ball hit at the top and bottom bar
        {
            delta_y_second_ball = -delta_y_second_ball;
        }

        //Distance update
        distance_between_box.Text = result.ToString();
        //Tracking red ball position
        red_ball_position_box.Text = "(" + center_first_ball_x +", " + center_first_ball_y + ")";
        //Tracking blue ball position
        blue_ball_position_box.Text = "(" + center_second_ball_x + ", " + center_second_ball_y + ")";

    }




    //OnPaint function
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
    }




    //Graphic Panel
    public class Graphicpanel : Panel
    {
        public Graphicpanel()
        {
            System.Console.WriteLine("A graphic panel was created");
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics board = e.Graphics;
            board.FillEllipse(red_brush, center_first_ball_x, center_first_ball_y, ball_size, ball_size);
            board.FillEllipse(blue_brush, center_second_ball_x, center_second_ball_y, ball_size, ball_size);
            base.OnPaint(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            System.Console.WriteLine("Keyboard is pressed");
            if(e.KeyCode == Keys.Right)
            {
                first_ball_angle_radians += turning_angle;
                delta_x_first_ball = first_ball_per_tic * Math.Cos(first_ball_angle_radians);
                delta_y_first_ball = -first_ball_per_tic * Math.Sin(first_ball_angle_radians);

            }
            else if(e.KeyCode == Keys.Left)
            {
                first_ball_angle_radians -= turning_angle;
                delta_x_first_ball = first_ball_per_tic * Math.Cos(first_ball_angle_radians);
                delta_y_first_ball = -first_ball_per_tic * Math.Sin(first_ball_angle_radians);   
            }
            Invalidate();
            base.OnKeyDown(e);
        }//End of OnKeyDown



        
        //On key press
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if(char.IsLetterOrDigit (e.KeyChar))
            if (e.KeyChar == 'e')
            {
                first_ball_angle_radians = 0.0;
            }
            else if(e.KeyChar == 'n')
            {
                first_ball_angle_radians = Math.PI / 2.0;
            }
            else if(e.KeyChar == 'w')
            {
                first_ball_angle_radians = Math.PI;
            }
            else if(e.KeyChar == 's')
            {
                first_ball_angle_radians = 3.0 * Math.PI / 2.0;
            }

            delta_x_first_ball = first_ball_per_tic * Math.Cos(first_ball_angle_radians);
            delta_y_first_ball = -first_ball_per_tic * Math.Sin(first_ball_angle_radians);
            Invalidate();
            base.OnKeyPress(e);

        }

    }
}