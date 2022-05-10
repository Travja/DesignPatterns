package me.travja.decorator.models.reader;

import java.io.IOException;

public class ShiftDownReader extends DecoReader {


    public ShiftDownReader(DecoReader reader) {
        super(reader);
    }

    public char shift(char c) {
        boolean requiresShift = c != -1 && c != '\n';
        return (char) (c - (requiresShift ? 1 : 0));
    }

    @Override
    public int read(char[] cbuf, int off, int len) throws IOException {
        int read = super.read(cbuf, off, len);

        for (int i = 0; i < cbuf.length; i++) {
            cbuf[i] = shift(cbuf[i]);
        }

        return read;
    }

}
