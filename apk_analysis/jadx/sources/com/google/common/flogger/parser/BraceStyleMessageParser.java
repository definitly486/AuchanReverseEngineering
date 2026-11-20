package com.google.common.flogger.parser;

/* JADX INFO: loaded from: classes2.dex */
public abstract class BraceStyleMessageParser extends MessageParser {
    private static final char BRACE_STYLE_SEPARATOR = ',';

    abstract void parseBraceFormatTerm(MessageBuilder<?> messageBuilder, int i, String str, int i2, int i3, int i4);

    @Override // com.google.common.flogger.parser.MessageParser
    public final void unescape(StringBuilder sb, String str, int i, int i2) {
        unescapeBraceFormat(sb, str, i, i2);
    }

    @Override // com.google.common.flogger.parser.MessageParser
    protected final <T> void parseImpl(MessageBuilder<T> messageBuilder) {
        int i;
        char cCharAt;
        int i2;
        String message = messageBuilder.getMessage();
        int iNextBraceFormatTerm = nextBraceFormatTerm(message, 0);
        while (iNextBraceFormatTerm >= 0) {
            int i3 = iNextBraceFormatTerm + 1;
            int i4 = i3;
            int i5 = 0;
            while (true) {
                if (i4 < message.length()) {
                    i = i4 + 1;
                    cCharAt = message.charAt(i4);
                    char c = (char) (cCharAt - '0');
                    if (c < '\n') {
                        i5 = (i5 * 10) + c;
                        if (i5 >= 1000000) {
                            throw ParseException.withBounds("index too large", message, i3, i);
                        }
                        i4 = i;
                    }
                } else {
                    throw ParseException.withStartPosition("unterminated parameter", message, iNextBraceFormatTerm);
                }
            }
            int i6 = i4 - i3;
            if (i6 == 0) {
                throw ParseException.withBounds("missing index", message, iNextBraceFormatTerm, i);
            }
            if (message.charAt(i3) == '0' && i6 > 1) {
                throw ParseException.withBounds("index has leading zero", message, i3, i4);
            }
            if (cCharAt == '}') {
                i2 = i;
                i = -1;
            } else {
                if (cCharAt != ',') {
                    throw ParseException.withBounds("malformed index", message, i3, i);
                }
                int i7 = i;
                while (true) {
                    if (i7 == message.length()) {
                        throw ParseException.withStartPosition("unterminated parameter", message, iNextBraceFormatTerm);
                    }
                    int i8 = i7 + 1;
                    if (message.charAt(i7) == '}') {
                        i2 = i8;
                        break;
                    }
                    i7 = i8;
                }
            }
            parseBraceFormatTerm(messageBuilder, i5, message, iNextBraceFormatTerm, i, i2);
            messageBuilder = messageBuilder;
            iNextBraceFormatTerm = nextBraceFormatTerm(message, i2);
        }
    }

    static int nextBraceFormatTerm(String str, int i) {
        while (i < str.length()) {
            int i2 = i + 1;
            char cCharAt = str.charAt(i);
            if (cCharAt == '{') {
                return i;
            }
            if (cCharAt == '\'') {
                if (i2 == str.length()) {
                    throw ParseException.withStartPosition("trailing single quote", str, i);
                }
                int i3 = i + 2;
                if (str.charAt(i2) == '\'') {
                    i = i3;
                } else {
                    while (true) {
                        if (i3 == str.length()) {
                            throw ParseException.withStartPosition("unmatched single quote", str, i);
                        }
                        i2 = i3 + 1;
                        if (str.charAt(i3) == '\'') {
                            break;
                        }
                        i3 = i2;
                    }
                }
            }
            i = i2;
        }
        return -1;
    }

    static void unescapeBraceFormat(StringBuilder sb, String str, int i, int i2) {
        int i3 = i;
        boolean z = false;
        while (i < i2) {
            int i4 = i + 1;
            char cCharAt = str.charAt(i);
            if (cCharAt == '\\' || cCharAt == '\'') {
                if (cCharAt == '\\') {
                    int i5 = i + 2;
                    if (str.charAt(i4) != '\'') {
                        i = i5;
                    } else {
                        i4 = i5;
                    }
                }
                sb.append((CharSequence) str, i3, i);
                if (i4 == i2) {
                    i3 = i4;
                    break;
                }
                if (z) {
                    z = false;
                } else {
                    if (str.charAt(i4) != '\'') {
                        z = true;
                    } else {
                        i = i4 + 1;
                    }
                    i3 = i4;
                }
                i = i4;
                i3 = i4;
            } else {
                i = i4;
            }
        }
        if (i3 < i2) {
            sb.append((CharSequence) str, i3, i2);
        }
    }
}
