import javax.swing.*;
import java.awt.*;
import java.util.Timer;
import java.util.TimerTask;

public class TimerFrame extends JFrame {
    private JPanel panel1;
    private JLabel lblTimer;

    public TimerFrame(){
        setSize(200,100);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE);
        setContentPane(panel1);
        setVisible(true);
        RunTimer();

    }

    private void RunTimer(){
        Timer timer = new Timer();

        timer.scheduleAtFixedRate(new TimerTask() {
            int i = 30;

            public void run() {

                lblTimer.setText("Осталось: " + i);
                i--;

                if (i < 0) {
                    timer.cancel();
                    lblTimer.setText("Конец");
                    dispose();
                }
            }
        }, 0, 1000);

    }
}
