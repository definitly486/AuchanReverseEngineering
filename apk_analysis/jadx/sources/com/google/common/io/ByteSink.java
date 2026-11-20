package com.google.common.io;

import com.google.common.annotations.GwtIncompatible;
import com.google.common.annotations.J2ktIncompatible;
import com.google.common.base.Preconditions;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.io.BufferedOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.nio.charset.Charset;

/* JADX INFO: loaded from: classes2.dex */
@J2ktIncompatible
@GwtIncompatible
public abstract class ByteSink {
    public abstract OutputStream openStream();

    protected ByteSink() {
    }

    public CharSink asCharSink(Charset charset) {
        return new AsCharSink(charset);
    }

    public OutputStream openBufferedStream() {
        OutputStream outputStreamOpenStream = openStream();
        if (outputStreamOpenStream instanceof BufferedOutputStream) {
            return (BufferedOutputStream) outputStreamOpenStream;
        }
        return new BufferedOutputStream(outputStreamOpenStream);
    }

    public void write(byte[] bArr) throws IOException {
        Preconditions.checkNotNull(bArr);
        OutputStream outputStreamOpenStream = openStream();
        try {
            outputStreamOpenStream.write(bArr);
            outputStreamOpenStream.close();
        } catch (Throwable th) {
            if (outputStreamOpenStream != null) {
                try {
                    outputStreamOpenStream.close();
                } catch (Throwable th2) {
                    th.addSuppressed(th2);
                }
            }
            throw th;
        }
    }

    @CanIgnoreReturnValue
    public long writeFrom(InputStream inputStream) throws IOException {
        Preconditions.checkNotNull(inputStream);
        OutputStream outputStreamOpenStream = openStream();
        try {
            long jCopy = ByteStreams.copy(inputStream, outputStreamOpenStream);
            if (outputStreamOpenStream != null) {
                outputStreamOpenStream.close();
            }
            return jCopy;
        } catch (Throwable th) {
            if (outputStreamOpenStream != null) {
                try {
                    outputStreamOpenStream.close();
                } catch (Throwable th2) {
                    th.addSuppressed(th2);
                }
            }
            throw th;
        }
    }

    private final class AsCharSink extends CharSink {
        private final Charset charset;

        private AsCharSink(Charset charset) {
            this.charset = (Charset) Preconditions.checkNotNull(charset);
        }

        @Override // com.google.common.io.CharSink
        public Writer openStream() {
            return new OutputStreamWriter(ByteSink.this.openStream(), this.charset);
        }

        public String toString() {
            return ByteSink.this.toString() + ".asCharSink(" + this.charset + ")";
        }
    }
}
