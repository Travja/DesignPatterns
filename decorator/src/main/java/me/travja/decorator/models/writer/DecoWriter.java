package me.travja.decorator.models.writer;

import lombok.Getter;

import java.io.FileWriter;
import java.io.IOException;
import java.io.Writer;

public class DecoWriter extends Writer {

    @Getter
    private final FileWriter fileWriter;
    @Getter
    protected     DecoWriter writer;

    public DecoWriter(FileWriter fileWriter) {
        this.fileWriter = fileWriter;
    }

    public DecoWriter(DecoWriter writer) {
        this(writer.getFileWriter());
        this.writer = writer;
    }

    @Override
    public void write(char[] cbuf, int off, int len) throws IOException {
        if (writer != null)
            writer.write(cbuf, off, len);
        else
            fileWriter.write(cbuf, off, len);
    }

    @Override
    public void write(String str) throws IOException {
        if (writer != null)
            writer.write(str);
        else
            fileWriter.write(str);
    }

    @Override
    public void flush() throws IOException {
        fileWriter.flush();
    }

    @Override
    public void close() throws IOException {
        fileWriter.close();
    }

}
