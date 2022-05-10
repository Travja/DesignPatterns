package me.travja.decorator.models.reader;

import lombok.Getter;

import java.io.FileReader;
import java.io.IOException;
import java.io.Reader;

public class DecoReader extends Reader {

    @Getter
    private final FileReader fileReader;
    @Getter
    protected     DecoReader reader;

    public DecoReader(FileReader fileReader) {
        this.fileReader = fileReader;
    }

    public DecoReader(DecoReader reader) {
        this(reader.getFileReader());
        this.reader = reader;
    }

    @Override
    public int read(char[] cbuf, int off, int len) throws IOException {
        if (reader != null)
            return reader.read(cbuf, off, len);
        else
            return fileReader.read(cbuf, off, len);
    }

    @Override
    public void close() throws IOException {
        fileReader.close();
    }

    public String readLine() throws IOException {
        int           c;
        StringBuilder builder = null;
        while ((c = read()) != -1) {
            if (builder == null)
                builder = new StringBuilder();
            builder.append((char) c);
        }

        return builder != null ? builder.toString() : null;
    }
}
