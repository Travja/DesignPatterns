package me.travja.decorator;

import me.travja.decorator.models.reader.DecoReader;
import me.travja.decorator.models.reader.LineEndingReader;
import me.travja.decorator.models.reader.ShiftDownReader;
import me.travja.decorator.models.writer.DecoWriter;
import me.travja.decorator.models.writer.ShiftUpWriter;
import me.travja.decorator.models.writer.SignatureWriter;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class Decorator {

    public static void main(String[] args) {
        /*
        If we wrap SignatureWriter with ShiftUpWriter, we get a clear-text signature at the top of the file.
        The other way around, the signature gets shifted along with all the rest of the text.
         */
        try (DecoWriter sigWriter =
                     new SignatureWriter(new ShiftUpWriter(new FileWriter("asdf.txt")))) {
            sigWriter.write("Writing good info\r\n");
            sigWriter.write("Hopefully this all works out how it should.\r\n");
        } catch (IOException e) {
            System.err.println("Could not write file...");
        } finally {
            System.out.println("Wrote file");
        }


        try (DecoReader reader =
                     new LineEndingReader(new ShiftDownReader(new DecoReader(new FileReader("asdf.txt"))))) {
            String        line;
            StringBuilder builder = new StringBuilder();
            while ((line = reader.readLine()) != null) {
                builder.append(line);
            }

            System.out.println(builder.toString().replace("\n", "\\n\n").replace("\r", "\\r"));
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}