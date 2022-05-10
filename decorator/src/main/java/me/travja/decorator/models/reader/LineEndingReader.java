package me.travja.decorator.models.reader;

import java.io.FileReader;
import java.io.IOException;

public class LineEndingReader extends DecoReader {

    public LineEndingReader(FileReader fileReader) {
        super(fileReader);
    }

    public LineEndingReader(DecoReader reader) {
        super(reader);
    }

    @Override
    public int read(char[] cbuf, int off, int len) throws IOException {
        int read = super.read(cbuf, off, len);

        for (int i = 0; i < cbuf.length; i++) {
            char c = cbuf[i];
            if (c == '\r') {
                int followingChar = super.read();
                if (followingChar == '\n') {
                    cbuf[i] = '\n';
                    read++;
                }
            }
        }


        return read;
    }
}
