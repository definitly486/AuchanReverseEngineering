package com.google.common.io;

import androidx.core.location.LocationRequestCompat;
import com.google.common.annotations.GwtIncompatible;
import com.google.common.annotations.J2ktIncompatible;
import com.google.common.base.Ascii;
import com.google.common.base.Optional;
import com.google.common.base.Preconditions;
import com.google.common.base.Splitter;
import com.google.common.collect.AbstractIterator;
import com.google.common.collect.ImmutableList;
import com.google.common.collect.Streams;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.MustBeClosed;
import java.io.BufferedReader;
import java.io.Closeable;
import java.io.IOException;
import java.io.InputStream;
import java.io.Reader;
import java.io.StringReader;
import java.io.UncheckedIOException;
import java.io.Writer;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.function.Consumer;
import java.util.stream.Stream;

/* JADX INFO: loaded from: classes2.dex */
@J2ktIncompatible
@GwtIncompatible
public abstract class CharSource {
    public abstract Reader openStream();

    protected CharSource() {
    }

    public ByteSource asByteSource(Charset charset) {
        return new AsByteSource(charset);
    }

    public BufferedReader openBufferedStream() {
        Reader readerOpenStream = openStream();
        if (readerOpenStream instanceof BufferedReader) {
            return (BufferedReader) readerOpenStream;
        }
        return new BufferedReader(readerOpenStream);
    }

    @IgnoreJRERequirement
    @MustBeClosed
    public Stream<String> lines() {
        final BufferedReader bufferedReaderOpenBufferedStream = openBufferedStream();
        return (Stream) bufferedReaderOpenBufferedStream.lines().onClose(new Runnable() { // from class: com.google.common.io.CharSource$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                CharSource.closeUnchecked(bufferedReaderOpenBufferedStream);
            }
        });
    }

    /* JADX INFO: Access modifiers changed from: private */
    @IgnoreJRERequirement
    public static void closeUnchecked(Closeable closeable) {
        try {
            closeable.close();
        } catch (IOException e) {
            throw new UncheckedIOException(e);
        }
    }

    public Optional<Long> lengthIfKnown() {
        return Optional.absent();
    }

    /* JADX INFO: Thrown type has an unknown type hierarchy: X */
    public long length() throws X {
        Optional<Long> optionalLengthIfKnown = lengthIfKnown();
        if (optionalLengthIfKnown.isPresent()) {
            return optionalLengthIfKnown.get().longValue();
        }
        Closer closerCreate = Closer.create();
        try {
            long jCountBySkipping = countBySkipping((Reader) closerCreate.register(openStream()));
            closerCreate.close();
            return jCountBySkipping;
        } catch (Throwable th) {
            try {
                throw closerCreate.rethrow(th);
            } catch (Throwable th2) {
                closerCreate.close();
                throw th2;
            }
        }
    }

    private static long countBySkipping(Reader reader) throws IOException {
        long j = 0;
        while (true) {
            long jSkip = reader.skip(LocationRequestCompat.PASSIVE_INTERVAL);
            if (jSkip == 0) {
                return j;
            }
            j += jSkip;
        }
    }

    /* JADX INFO: Thrown type has an unknown type hierarchy: X */
    @CanIgnoreReturnValue
    public long copyTo(Appendable appendable) throws X {
        Preconditions.checkNotNull(appendable);
        Closer closerCreate = Closer.create();
        try {
            long jCopy = CharStreams.copy((Reader) closerCreate.register(openStream()), appendable);
            closerCreate.close();
            return jCopy;
        } catch (Throwable th) {
            try {
                throw closerCreate.rethrow(th);
            } catch (Throwable th2) {
                closerCreate.close();
                throw th2;
            }
        }
    }

    /* JADX INFO: Thrown type has an unknown type hierarchy: X */
    @CanIgnoreReturnValue
    public long copyTo(CharSink charSink) throws X {
        Preconditions.checkNotNull(charSink);
        Closer closerCreate = Closer.create();
        try {
            long jCopy = CharStreams.copy((Reader) closerCreate.register(openStream()), (Writer) closerCreate.register(charSink.openStream()));
            closerCreate.close();
            return jCopy;
        } catch (Throwable th) {
            try {
                throw closerCreate.rethrow(th);
            } catch (Throwable th2) {
                closerCreate.close();
                throw th2;
            }
        }
    }

    /* JADX INFO: Thrown type has an unknown type hierarchy: X */
    public String read() throws X {
        Closer closerCreate = Closer.create();
        try {
            String string = CharStreams.toString((Reader) closerCreate.register(openStream()));
            closerCreate.close();
            return string;
        } catch (Throwable th) {
            try {
                throw closerCreate.rethrow(th);
            } catch (Throwable th2) {
                closerCreate.close();
                throw th2;
            }
        }
    }

    /* JADX INFO: Thrown type has an unknown type hierarchy: X */
    public String readFirstLine() throws X {
        Closer closerCreate = Closer.create();
        try {
            String line = ((BufferedReader) closerCreate.register(openBufferedStream())).readLine();
            closerCreate.close();
            return line;
        } catch (Throwable th) {
            try {
                throw closerCreate.rethrow(th);
            } catch (Throwable th2) {
                closerCreate.close();
                throw th2;
            }
        }
    }

    /* JADX INFO: Thrown type has an unknown type hierarchy: X */
    public ImmutableList<String> readLines() throws X {
        Closer closerCreate = Closer.create();
        try {
            BufferedReader bufferedReader = (BufferedReader) closerCreate.register(openBufferedStream());
            ArrayList arrayList = new ArrayList();
            while (true) {
                String line = bufferedReader.readLine();
                if (line != null) {
                    arrayList.add(line);
                } else {
                    ImmutableList<String> immutableListCopyOf = ImmutableList.copyOf((Collection) arrayList);
                    closerCreate.close();
                    return immutableListCopyOf;
                }
            }
        } catch (Throwable th) {
            try {
                throw closerCreate.rethrow(th);
            } catch (Throwable th2) {
                closerCreate.close();
                throw th2;
            }
        }
    }

    /* JADX INFO: Thrown type has an unknown type hierarchy: X */
    @CanIgnoreReturnValue
    @ParametricNullness
    public <T> T readLines(LineProcessor<T> lineProcessor) throws X {
        Preconditions.checkNotNull(lineProcessor);
        Closer closerCreate = Closer.create();
        try {
            T t = (T) CharStreams.readLines((Reader) closerCreate.register(openStream()), lineProcessor);
            closerCreate.close();
            return t;
        } catch (Throwable th) {
            try {
                throw closerCreate.rethrow(th);
            } catch (Throwable th2) {
                closerCreate.close();
                throw th2;
            }
        }
    }

    @IgnoreJRERequirement
    public void forEachLine(Consumer<? super String> consumer) throws IOException {
        try {
            Stream<String> streamLines = lines();
            try {
                streamLines.forEachOrdered(consumer);
                streamLines.close();
            } catch (Throwable th) {
                if (streamLines != null) {
                    try {
                        streamLines.close();
                    } catch (Throwable th2) {
                        th.addSuppressed(th2);
                    }
                }
                throw th;
            }
        } catch (UncheckedIOException e) {
            throw e.getCause();
        }
    }

    /* JADX INFO: Thrown type has an unknown type hierarchy: X */
    public boolean isEmpty() throws X {
        Optional<Long> optionalLengthIfKnown = lengthIfKnown();
        if (optionalLengthIfKnown.isPresent()) {
            return optionalLengthIfKnown.get().longValue() == 0;
        }
        Closer closerCreate = Closer.create();
        try {
            boolean z = ((Reader) closerCreate.register(openStream())).read() == -1;
            closerCreate.close();
            return z;
        } catch (Throwable th) {
            try {
                throw closerCreate.rethrow(th);
            } catch (Throwable th2) {
                closerCreate.close();
                throw th2;
            }
        }
    }

    public static CharSource concat(Iterable<? extends CharSource> iterable) {
        return new ConcatenatedCharSource(iterable);
    }

    public static CharSource concat(Iterator<? extends CharSource> it) {
        return concat(ImmutableList.copyOf(it));
    }

    public static CharSource concat(CharSource... charSourceArr) {
        return concat(ImmutableList.copyOf(charSourceArr));
    }

    public static CharSource wrap(CharSequence charSequence) {
        if (charSequence instanceof String) {
            return new StringCharSource((String) charSequence);
        }
        return new CharSequenceCharSource(charSequence);
    }

    public static CharSource empty() {
        return EmptyCharSource.INSTANCE;
    }

    private final class AsByteSource extends ByteSource {
        final Charset charset;

        AsByteSource(Charset charset) {
            this.charset = (Charset) Preconditions.checkNotNull(charset);
        }

        @Override // com.google.common.io.ByteSource
        public CharSource asCharSource(Charset charset) {
            if (charset.equals(this.charset)) {
                return CharSource.this;
            }
            return super.asCharSource(charset);
        }

        @Override // com.google.common.io.ByteSource
        public InputStream openStream() {
            return new ReaderInputStream(CharSource.this.openStream(), this.charset, 8192);
        }

        public String toString() {
            return CharSource.this.toString() + ".asByteSource(" + this.charset + ")";
        }
    }

    private static class CharSequenceCharSource extends CharSource {
        private static final Splitter LINE_SPLITTER = Splitter.onPattern("\r\n|\n|\r");
        final CharSequence seq;

        CharSequenceCharSource(CharSequence charSequence) {
            this.seq = (CharSequence) Preconditions.checkNotNull(charSequence);
        }

        @Override // com.google.common.io.CharSource
        public Reader openStream() {
            return new CharSequenceReader(this.seq);
        }

        @Override // com.google.common.io.CharSource
        public String read() {
            return this.seq.toString();
        }

        @Override // com.google.common.io.CharSource
        public boolean isEmpty() {
            return this.seq.length() == 0;
        }

        @Override // com.google.common.io.CharSource
        public long length() {
            return this.seq.length();
        }

        @Override // com.google.common.io.CharSource
        public Optional<Long> lengthIfKnown() {
            return Optional.of(Long.valueOf(this.seq.length()));
        }

        private Iterator<String> linesIterator() {
            return new AbstractIterator<String>() { // from class: com.google.common.io.CharSource.CharSequenceCharSource.1
                final Iterator<String> lines;

                {
                    this.lines = CharSequenceCharSource.LINE_SPLITTER.split(CharSequenceCharSource.this.seq).iterator();
                }

                /* JADX INFO: Access modifiers changed from: protected */
                @Override // com.google.common.collect.AbstractIterator
                public String computeNext() {
                    if (this.lines.hasNext()) {
                        String next = this.lines.next();
                        if (this.lines.hasNext() || !next.isEmpty()) {
                            return next;
                        }
                    }
                    return endOfData();
                }
            };
        }

        @Override // com.google.common.io.CharSource
        @IgnoreJRERequirement
        public Stream<String> lines() {
            return Streams.stream(linesIterator());
        }

        @Override // com.google.common.io.CharSource
        public String readFirstLine() {
            Iterator<String> itLinesIterator = linesIterator();
            if (itLinesIterator.hasNext()) {
                return itLinesIterator.next();
            }
            return null;
        }

        @Override // com.google.common.io.CharSource
        public ImmutableList<String> readLines() {
            return ImmutableList.copyOf(linesIterator());
        }

        @Override // com.google.common.io.CharSource
        @ParametricNullness
        public <T> T readLines(LineProcessor<T> lineProcessor) {
            Iterator<String> itLinesIterator = linesIterator();
            while (itLinesIterator.hasNext() && lineProcessor.processLine(itLinesIterator.next())) {
            }
            return lineProcessor.getResult();
        }

        public String toString() {
            return "CharSource.wrap(" + Ascii.truncate(this.seq, 30, "...") + ")";
        }
    }

    private static class StringCharSource extends CharSequenceCharSource {
        StringCharSource(String str) {
            super(str);
        }

        @Override // com.google.common.io.CharSource.CharSequenceCharSource, com.google.common.io.CharSource
        public Reader openStream() {
            return new StringReader((String) this.seq);
        }

        @Override // com.google.common.io.CharSource
        public long copyTo(Appendable appendable) throws IOException {
            appendable.append(this.seq);
            return this.seq.length();
        }

        /* JADX INFO: Thrown type has an unknown type hierarchy: X */
        @Override // com.google.common.io.CharSource
        public long copyTo(CharSink charSink) throws X {
            Preconditions.checkNotNull(charSink);
            Closer closerCreate = Closer.create();
            try {
                ((Writer) closerCreate.register(charSink.openStream())).write((String) this.seq);
                long length = this.seq.length();
                closerCreate.close();
                return length;
            } catch (Throwable th) {
                try {
                    throw closerCreate.rethrow(th);
                } catch (Throwable th2) {
                    closerCreate.close();
                    throw th2;
                }
            }
        }
    }

    private static final class EmptyCharSource extends StringCharSource {
        private static final EmptyCharSource INSTANCE = new EmptyCharSource();

        private EmptyCharSource() {
            super("");
        }

        @Override // com.google.common.io.CharSource.CharSequenceCharSource
        public String toString() {
            return "CharSource.empty()";
        }
    }

    private static final class ConcatenatedCharSource extends CharSource {
        private final Iterable<? extends CharSource> sources;

        ConcatenatedCharSource(Iterable<? extends CharSource> iterable) {
            this.sources = (Iterable) Preconditions.checkNotNull(iterable);
        }

        @Override // com.google.common.io.CharSource
        public Reader openStream() {
            return new MultiReader(this.sources.iterator());
        }

        @Override // com.google.common.io.CharSource
        public boolean isEmpty() {
            Iterator<? extends CharSource> it = this.sources.iterator();
            while (it.hasNext()) {
                if (!it.next().isEmpty()) {
                    return false;
                }
            }
            return true;
        }

        @Override // com.google.common.io.CharSource
        public Optional<Long> lengthIfKnown() {
            Iterator<? extends CharSource> it = this.sources.iterator();
            long jLongValue = 0;
            while (it.hasNext()) {
                Optional<Long> optionalLengthIfKnown = it.next().lengthIfKnown();
                if (!optionalLengthIfKnown.isPresent()) {
                    return Optional.absent();
                }
                jLongValue += optionalLengthIfKnown.get().longValue();
            }
            return Optional.of(Long.valueOf(jLongValue));
        }

        @Override // com.google.common.io.CharSource
        public long length() {
            Iterator<? extends CharSource> it = this.sources.iterator();
            long length = 0;
            while (it.hasNext()) {
                length += it.next().length();
            }
            return length;
        }

        public String toString() {
            return "CharSource.concat(" + this.sources + ")";
        }
    }
}
