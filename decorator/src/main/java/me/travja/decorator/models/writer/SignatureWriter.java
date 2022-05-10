package me.travja.decorator.models.writer;

import java.io.FileWriter;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class SignatureWriter extends DecoWriter {

    private static DateFormat format = new SimpleDateFormat("MM-dd-yyyy hh:mm:ss");

    private boolean signed    = false;
    private String  signature = "** Travis Eggett ${date} **";

    public SignatureWriter(FileWriter fileWriter) {
        super(fileWriter);
    }

    public SignatureWriter(DecoWriter writer) {
        super(writer);
    }

    private void writeSignature() throws IOException {
        if (signed) return;

        super.write(signature.replace("${date}", format.format(new Date())) + "\r\n");
        signed = true;
    }

    @Override
    public void write(char[] cbuf, int off, int len) throws IOException {
        writeSignature();
        super.write(cbuf, off, len);
    }

    @Override
    public void write(String str) throws IOException {
        writeSignature();
        super.write(str);
    }

}
