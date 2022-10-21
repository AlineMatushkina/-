import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.*;
import java.io.*;
import java.util.stream.Collectors;
import java.sql.*;
public class GameFrame extends JFrame {
    private JPanel panel1;
    private JPanel controlPanel;
    private JPanel questionAndAnswersPanel;
    private JLabel lblQuestionText;
    private JButton btnAnswer3;
    private JButton btnAnswer1;
    private JButton btnAnswer4;
    private JButton btnAnswer2;
    private JList lstLevel;
    private JButton btnHallHelp;
    private JButton btnCallFriend;
    private JButton btnMistake;
    private JButton btnChangeQuestion;
    private JButton btnFiftyFifty;
    private JButton btnGetMoney;

    ArrayList<Question> questions = new ArrayList<Question>();
    private Random  rnd = new Random();
    int Level = 0;
    int CountAttempts = 0;
    int IndexFireproofAmount = -1;
    Question currentQuestion;

    private int CountOfHints = 0;

    public GameFrame(){
        setSize(650,450);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setContentPane(panel1);

        SetActionCommandBtnAnswers();
        SetActionListenerBtnAswers();
        SetActionListenerBtnHelps();

        //ReadFile();
        startGame();

    }

    public static void main(String [] args){
        GameFrame gf = new GameFrame();
        gf.setVisible(true);
    }

    private void ReadFile()
    {
        try{
            FileInputStream fstream = new FileInputStream("C:\\Users\\ASUS\\Desktop\\WhoWantsToBeAMillionaire\\src\\Voprosi.txt");
            BufferedReader br = new BufferedReader(new InputStreamReader(fstream));
            String strLine;

            while ((strLine = br.readLine()) != null) {
                String[] s = strLine.split("\t");
                questions.add(new Question(s));
            }
        } catch (IOException e) {
            System.out.println("Ошибка");
        }
    }

    private void ShowQuestion(Question q)
    {
        lblQuestionText.setText(q.Text);
        btnAnswer1.setText(q.Answers[0]);
        btnAnswer2.setText(q.Answers[1]);
        btnAnswer3.setText(q.Answers[2]);
        btnAnswer4.setText(q.Answers[3]);
    }

    private Question GetQuestion(int level)
    {
        Question cur_question = null;
        try{
            Class.forName("org.sqlite.JDBC");
            Connection conn = DriverManager.getConnection("jdbc:sqlite:C:\\Users\\ASUS\\Desktop\\WhoWantsToBeAMillionaire\\Ланин.db");

            Statement statmt = conn.createStatement();
            String query = "select * from Voprosi where field7 = " + String.valueOf(level) +  " ORDER BY random() LIMIT 1;";

            ResultSet resSet = statmt.executeQuery(query);


            while (resSet.next()) {
                String [] array = new String[7];
                for (int i = 0; i < 7; ++i)
                    array[i] = resSet.getString(i + 1);
                cur_question = new Question(array);
            }

            resSet.close();
            conn.close();

        } catch (Exception ex) {
            System.out.println(ex.toString());
        }

        return cur_question;
    }

    private void NextStep()
    {
        CountAttempts = 0;
        JButton[] btns = new JButton[]{btnAnswer1, btnAnswer2,
                btnAnswer3, btnAnswer4};

        for(JButton btn: btns)
            btn.setEnabled(true);

        Level++;
        if (Level == lstLevel.getModel().getSize() + 1){
            JOptionPane.showMessageDialog(this, "Поздравляю, Вы победили! Вы забираете "  + lstLevel.getModel().getElementAt(0).toString());
            startGame();
            return;
        }
        currentQuestion = GetQuestion(Level);
        ShowQuestion(currentQuestion);
        lstLevel.setSelectedIndex(lstLevel.getModel().getSize()-Level);
    }

    private void startGame()
    {
        Level = 0;
        CountAttempts = 0;
        CountOfHints = 0;
        setVisible(false);
        ShowAllSum();
        EnableHintsButton();
        NextStep();
        setVisible(true);
    }


    private void bntAnswerPerformed(java.awt.event.ActionEvent evt) {

        if (currentQuestion.RightAnswer.equals(evt.getActionCommand()))
            NextStep();
        else
        {
            if(CountAttempts > 0){
                CountAttempts = 0;
                JOptionPane.showMessageDialog(this, "Неверный ответ! Попробуйте ещё раз");
                return;
            }
            JOptionPane.showMessageDialog(this, "Неверный ответ!");
            int indexLevel = lstLevel.getModel().getSize()-Level + 1;
            String resultSum = "0";
            if (indexLevel < IndexFireproofAmount) resultSum = lstLevel.getModel().getElementAt(IndexFireproofAmount - 1).toString();
            JOptionPane.showMessageDialog(this, "Вы выиграли " +resultSum + "!");
            startGame();
        }

    }

    private void bntFiftyFiftyActionPerformed(java.awt.event.ActionEvent evt) {
        JButton[] btns = new JButton[]{btnAnswer1, btnAnswer2,
                btnAnswer3, btnAnswer4};

        int count = 0;
        while (count < 2)
        {
            int n = rnd.nextInt(4);
            String ac = btns[n].getActionCommand();

            if (!ac.equals(currentQuestion.RightAnswer)
                    && btns[n].isEnabled())
            {
                btns[n].setEnabled(false);
                count++;
            }
        }

        btnFiftyFifty.setEnabled(false);
        CountOfHints++;
        if (CountOfHints == 4) DisableHintsButton();
    }

    private void btnGetMoneyActionPerformed(java.awt.event.ActionEvent evt) {
        String cur_sum = "0";
        int i = lstLevel.getSelectedIndex();
        if (i <= lstLevel.getModel().getSize() - 2){
            cur_sum = lstLevel.getModel().getElementAt(i + 1).toString();
        }
        JOptionPane.showMessageDialog(this, "Поздравляю! Вы забираете " + cur_sum);
        startGame();
    }

    private void btnMistakeActionPerformed(java.awt.event.ActionEvent evt) {
        CountAttempts++;
        btnMistake.setEnabled(false);
        CountOfHints++;
        if (CountOfHints == 4) DisableHintsButton();
    }

    private void btnChangeQuestionActionPerformed(java.awt.event.ActionEvent evt) {

        currentQuestion = GetQuestion(Level);
        ShowQuestion(currentQuestion);
        btnChangeQuestion.setEnabled(false);
        CountOfHints++;
        if (CountOfHints == 4) DisableHintsButton();
    }

    private void btnHallHelpActionPerformed(java.awt.event.ActionEvent evt) {

        int right_answer = Integer.parseInt(currentQuestion.RightAnswer) - 1;

        double [] result = new double[4];

        result[right_answer] = RandomValue(70, 100);
        double [] temp = new double[3];
        temp[0] = (100 - result[right_answer]) / 3.0;
        temp[1] = (100 - result[right_answer] - temp[0]) * 1 / 3.0;
        temp[2] = (100 - result[right_answer] - temp[0]) * 2 / 3.0;

        int j = 0;
        for (int i = 0; i < 4; ++i)
            if (i != right_answer)
                result[i] = temp[j++];

        String result_str = "Итоги голосования:\n";
        for (int i = 0; i < 4; ++i)
            result_str += String.valueOf(i + 1) + ") " + String.valueOf((int)(result[i] * 100) / 100.0) + "%\n";
        JOptionPane.showMessageDialog(this, result_str);
        btnHallHelp.setEnabled(false);
        CountOfHints++;
        if (CountOfHints == 4) DisableHintsButton();
    }


    private void btnCallFriendActionPerformed(java.awt.event.ActionEvent evt) {

        TimerFrame timer = new TimerFrame();

        btnCallFriend.setEnabled(false);
        CountOfHints++;
        if (CountOfHints == 4) DisableHintsButton();
    }

    private void SetActionListenerBtnAswers(){
        btnAnswer1.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                bntAnswerPerformed(e);
            }
        });

        btnAnswer2.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                bntAnswerPerformed(e);
            }
        });

        btnAnswer3.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                bntAnswerPerformed(e);
            }
        });

        btnAnswer4.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                bntAnswerPerformed(e);
            }
        });
    }

    private void SetActionListenerBtnHelps(){
        btnFiftyFifty.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                bntFiftyFiftyActionPerformed(e);
            }
        });

        btnMistake.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                btnMistakeActionPerformed(e);
            }
        });

        btnGetMoney.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                btnGetMoneyActionPerformed(e);
            }
        });

        btnChangeQuestion.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                btnChangeQuestionActionPerformed(e);
            }
        });

        btnHallHelp.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                btnHallHelpActionPerformed(e);
            }
        });

        btnCallFriend.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                btnCallFriendActionPerformed(e);
            }
        });
    }

    private void SetActionCommandBtnAnswers(){
        btnAnswer1.setActionCommand("1");
        btnAnswer2.setActionCommand("2");
        btnAnswer3.setActionCommand("3");
        btnAnswer4.setActionCommand("4");
    }

    private void EnableHintsButton(){
        btnFiftyFifty.setEnabled(true);
        btnMistake.setEnabled(true);
        btnChangeQuestion.setEnabled(true);
        btnHallHelp.setEnabled(true);
        btnCallFriend.setEnabled(true);
    }
    private void DisableHintsButton(){
        btnFiftyFifty.setEnabled(false);
        btnMistake.setEnabled(false);
        btnChangeQuestion.setEnabled(false);
        btnHallHelp.setEnabled(false);
        btnCallFriend.setEnabled(false);
    }

    private double RandomValue(double min, double max){
        Random r = new Random();
        return min + (max - min) * r.nextDouble();
    }


    private void ShowAllSum(){
        String sum = "Введите номер несгораемой суммы:\n" +
                "1)3 000 000\n" +
                "2)1 500 000\n" +
                "3)   800 000\n" +
                "4)   400 000\n" +
                "5)   200 000\n" +
                "6)   100 000\n" +
                "7)    50 000\n" +
                "8)    25 000\n" +
                "9)    15 000\n" +
                "10)   10 000\n" +
                "11)    5 000\n" +
                "12)    3 000\n" +
                "13)    2 000\n" +
                "14)    1 000\n" +
                "15)      500\n";
        String m = JOptionPane.showInputDialog(sum);
        if (CheckIndexSum(m)) IndexFireproofAmount = Integer.parseInt(m);
        else IndexFireproofAmount = lstLevel.getModel().getSize();

    }

    private boolean CheckIndexSum(String str){
        try{
            int number = Integer.parseInt(str);
            return number >= 1 && number <= 15;
        }
        catch (NumberFormatException ex){
            return false;
        }
    }
}
