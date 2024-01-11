package com.mron.app;

import com.mron.app.bean.ChatMessage;
import com.mron.app.bean.ChatMessage.Action;
import com.mron.app.frame.ClientFrame;
import com.mron.app.service.ClientService;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.*;

public class form extends javax.swing.JFrame {

    private Socket socket;
    private ChatMessage message;
    private ClientService service;

    public form() { createUIComponents();
        sendButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                
            }
        });
    }

    private class ListenerSocket implements Runnable {

        private ObjectInputStream input;

        public ListenerSocket(Socket socket) {
            try {
                this.input = new ObjectInputStream(socket.getInputStream());
            } catch (IOException ex) {
                Logger.getLogger(ClientFrame.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        @Override
        public void run() {
            ChatMessage message = null;
            try {
                while ((message = (ChatMessage) input.readObject()) != null) {
                    Action action = message.getAction();

                    if (action.equals(Action.CONNECT)) {
                        connected(message);
                    } else if (action.equals(Action.DISCONNECT)) {
                        disconnected();
                        socket.close();
                    } else if (action.equals(Action.SEND_ONE)) {
                        System.out.println("::: " + message.getText() + " :::");
                        receive(message);
                    } else if (action.equals(Action.USERS_ONLINE)) {
                        refreshOnlines(message);
                    }
                }
            } catch (IOException ex) {
                Logger.getLogger(ClientFrame.class.getName()).log(Level.SEVERE, null, ex);
            } catch (ClassNotFoundException ex) {
                Logger.getLogger(ClientFrame.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }

    private void connected(ChatMessage message) {
        if (message.getText().equals("NO")) {
            this.nameTextField.setText("");
            JOptionPane.showMessageDialog(this, "Соединение не установлено!\nПопробуйте еще раз с новым именем.");
            return;
        }

        this.message = message;
        this.connectButton.setEnabled(false);
        this.nameTextField.setEditable(false);

        this.disconnectButton.setEnabled(true);
        this.messageField.setEnabled(true);
        this.messagesArea.setEnabled(true);
        this.sendButton.setEnabled(true);

        JOptionPane.showMessageDialog(this, "Вы вошли в чат!");
    }

    private void disconnected() {

        this.connectButton.setEnabled(true);
        this.nameTextField.setEditable(true);

        this.disconnectButton.setEnabled(false);
        this.messageField.setEnabled(false);
        this.messagesArea.setEnabled(false);
        this.sendButton.setEnabled(false);

        this.messagesArea.setText("");
        this.messageField.setText("");

        JOptionPane.showMessageDialog(this, "Вы покинули сервер!");
    }

    private void receive(ChatMessage message) {
        this.messagesArea.append(message.getName() + ": " + message.getText() + "\n");
    }

    private void refreshOnlines(ChatMessage message) {
        System.out.println(message.getSetOnlines().toString());

        Set<String> names = message.getSetOnlines();

        names.remove(message.getName());

        String[] array = (String[]) names.toArray(new String[names.size()]);

        this.onlineList.setListData(array);
        this.onlineList.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        this.onlineList.setLayoutOrientation(JList.VERTICAL);
    }

    private void connectButtonActionPerformed(java.awt.event.ActionEvent evt) {
        String name = this.nameTextField.getText();

        if (!name.isEmpty()) {
            this.message = new ChatMessage();
            this.message.setAction(Action.CONNECT);
            this.message.setName(name);

            this.service = new ClientService();
            this.socket = this.service.connect();

            new Thread(new form.ListenerSocket(this.socket)).start();

            this.service.send(message);
        }
    }

    private void disconnectButtonActionPerformed(java.awt.event.ActionEvent evt) {
        ChatMessage message = new ChatMessage();
        message.setName(this.message.getName());
        message.setAction(Action.DISCONNECT);
        this.service.send(message);
        disconnected();
    }

    private void btnClearActionPerformed(java.awt.event.ActionEvent evt) {
        this.messageField.setText("");
    }

    private void sendButtonActionPerformed(java.awt.event.ActionEvent evt) {
        String text = this.messageField.getText();
        String name = this.message.getName();

        this.message = new ChatMessage();

        if (this.onlineList.getSelectedIndex() > -1) {
            this.message.setNameReserved((String) this.onlineList.getSelectedValue());
            this.message.setAction(Action.SEND_ONE);
            this.onlineList.clearSelection();
        } else {
            this.message.setAction(Action.SEND_ALL);
        }

        if (!text.isEmpty()) {
            this.message.setName(name);
            this.message.setText(text);

            this.messagesArea.append(name + ": " + text + "\n");

            this.service.send(this.message);
        }

        this.messageField.setText("");
    }

    private JButton sendButton;
    private JTextArea messagesArea;
    private JTextField messageField;
    private JTextField nameTextField;
    private JButton connectButton;
    private JButton disconnectButton;
    private JList onlineList;

    private void createUIComponents() {
        // TODO: place custom component creation code here
    }
}
