package com.google.common.io;

import com.google.common.annotations.GwtIncompatible;
import com.google.common.annotations.J2ktIncompatible;
import com.google.common.base.Preconditions;
import com.google.common.base.StandardSystemProperty;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.Writer;
import java.util.Iterator;
import java.util.stream.Stream;

/* JADX INFO: loaded from: classes2.dex */
@J2ktIncompatible
@GwtIncompatible
public abstract class CharSink {
    public abstract Writer openStream();

    protected CharSink() {
    }

    public Writer openBufferedStream() {
        Writer writerOpenStream = openStream();
        if (writerOpenStream instanceof BufferedWriter) {
            return (BufferedWriter) writerOpenStream;
        }
        return new BufferedWriter(writerOpenStream);
    }

    public void write(CharSequence charSequence) throws IOException {
        Preconditions.checkNotNull(charSequence);
        Writer writerOpenStream = openStream();
        try {
            writerOpenStream.append(charSequence);
            writerOpenStream.close();
        } catch (Throwable th) {
            if (writerOpenStream != null) {
                try {
                    writerOpenStream.close();
                } catch (Throwable th2) {
                    th.addSuppressed(th2);
                }
            }
            throw th;
        }
    }

    public void writeLines(Iterable<? extends CharSequence> iterable) throws IOException {
        writeLines(iterable, System.getProperty("line.separator"));
    }

    public void writeLines(Iterable<? extends CharSequence> iterable, String str) throws IOException {
        writeLines(iterable.iterator(), str);
    }

    @IgnoreJRERequirement
    public void writeLines(Stream<? extends CharSequence> stream) throws IOException {
        writeLines(stream, StandardSystemProperty.LINE_SEPARATOR.value());
    }

    @IgnoreJRERequirement
    public void writeLines(Stream<? extends CharSequence> stream, String str) throws IOException {
        writeLines(stream.iterator(), str);
    }

    private void writeLines(Iterator<? extends CharSequence> it, String str) throws IOException {
        Preconditions.checkNotNull(str);
        Writer writerOpenBufferedStream = openBufferedStream();
        while (it.hasNext()) {
            try {
                writerOpenBufferedStream.append(it.next()).append((CharSequence) str);
            } catch (Throwable th) {
                if (writerOpenBufferedStream != null) {
                    try {
                        writerOpenBufferedStream.close();
                    } catch (Throwable th2) {
                        th.addSuppressed(th2);
                    }
                }
                throw th;
            }
        }
        if (writerOpenBufferedStream != null) {
            writerOpenBufferedStream.close();
        }
    }

    @CanIgnoreReturnValue
    public long writeFrom(Readable readable) throws IOException {
        Preconditions.checkNotNull(readable);
        Writer writerOpenStream = openStream();
        try {
            long jCopy = CharStreams.copy(readable, writerOpenStream);
            if (writerOpenStream != null) {
                writerOpenStream.close();
            }
            return jCopy;
        } catch (Throwable th) {
            if (writerOpenStream != null) {
                try {
                    writerOpenStream.close();
                } catch (Throwable th2) {
                    th.addSuppressed(th2);
                }
            }
            throw th;
        }
    }
}
