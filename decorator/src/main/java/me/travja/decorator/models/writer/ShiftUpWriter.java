package me.travja.decorator.models.writer;

import java.io.FileWriter;
import java.io.IOException;

public class ShiftUpWriter extends DecoWriter {

    public ShiftUpWriter(FileWriter fileWriter) {
        super(fileWriter);
    }

    public ShiftUpWriter(DecoWriter writer) {
        super(writer);
    }

    public char[] shiftUp(char[] cbuf) {
        char[] chars = new char[cbuf.length];
        for (int i = 0; i < cbuf.length; i++) {
            char c = cbuf[i];
            // Don't shift a new line character
            chars[i] = c == '\n' ? c : ++c;
        }

        return chars;
    }

    public String shiftUp(String str) {
        return new String(shiftUp(str.toCharArray()));
    }

    @Override
    public void write(char[] cbuf, int off, int len) throws IOException {
        super.write(shiftUp(cbuf), off, len);
    }

    @Override
    public void write(String str) throws IOException {
        super.write(shiftUp(str));
    }

}
