package com.google.common.flogger.parser;

/* JADX INFO: loaded from: classes2.dex */
public abstract class PrintfMessageParser extends MessageParser {
    private static final String ALLOWED_NEWLINE_PATTERN = "\\n|\\r(?:\\n)?";
    private static final String SYSTEM_NEWLINE = getSafeSystemNewline();

    abstract int parsePrintfTerm(MessageBuilder<?> messageBuilder, int i, String str, int i2, int i3, int i4);

    static String getSafeSystemNewline() {
        try {
            String property = System.getProperty("line.separator");
            return property.matches(ALLOWED_NEWLINE_PATTERN) ? property : "\n";
        } catch (SecurityException unused) {
            return "\n";
        }
    }

    @Override // com.google.common.flogger.parser.MessageParser
    public final void unescape(StringBuilder sb, String str, int i, int i2) {
        unescapePrintf(sb, str, i, i2);
    }

    @Override // com.google.common.flogger.parser.MessageParser
    protected final <T> void parseImpl(MessageBuilder<T> messageBuilder) {
        int i;
        char cCharAt;
        int i2;
        int i3;
        int i4;
        int i5;
        String message = messageBuilder.getMessage();
        int iNextPrintfTerm = nextPrintfTerm(message, 0);
        int i6 = 0;
        int i7 = -1;
        while (iNextPrintfTerm >= 0) {
            int i8 = iNextPrintfTerm + 1;
            int i9 = i8;
            int i10 = 0;
            while (true) {
                if (i9 < message.length()) {
                    i = i9 + 1;
                    cCharAt = message.charAt(i9);
                    char c = (char) (cCharAt - '0');
                    if (c < '\n') {
                        i10 = (i10 * 10) + c;
                        if (i10 >= 1000000) {
                            throw ParseException.withBounds("index too large", message, iNextPrintfTerm, i);
                        }
                        i9 = i;
                    }
                } else {
                    throw ParseException.withStartPosition("unterminated parameter", message, iNextPrintfTerm);
                }
            }
            if (cCharAt == '$') {
                if (i9 - i8 == 0) {
                    throw ParseException.withBounds("missing index", message, iNextPrintfTerm, i);
                }
                if (message.charAt(i8) == '0') {
                    throw ParseException.withBounds("index has leading zero", message, iNextPrintfTerm, i);
                }
                int i11 = i10 - 1;
                if (i == message.length()) {
                    throw ParseException.withStartPosition("unterminated parameter", message, iNextPrintfTerm);
                }
                message.charAt(i);
                i5 = i6;
                i4 = i9 + 2;
                i2 = i;
                i3 = i11;
            } else if (cCharAt != '<') {
                int i12 = i6 + 1;
                i2 = i8;
                i3 = i6;
                i4 = i;
                i5 = i12;
            } else {
                if (i7 == -1) {
                    throw ParseException.withBounds("invalid relative parameter", message, iNextPrintfTerm, i);
                }
                if (i == message.length()) {
                    throw ParseException.withStartPosition("unterminated parameter", message, iNextPrintfTerm);
                }
                message.charAt(i);
                i5 = i6;
                i4 = i9 + 2;
                i2 = i;
                i3 = i7;
            }
            MessageBuilder<T> messageBuilder2 = messageBuilder;
            iNextPrintfTerm = nextPrintfTerm(message, parsePrintfTerm(messageBuilder2, i3, message, iNextPrintfTerm, i2, findFormatChar(message, iNextPrintfTerm, i4 - 1)));
            messageBuilder = messageBuilder2;
            i7 = i3;
            i6 = i5;
        }
    }

    static int nextPrintfTerm(String str, int i) {
        while (i < str.length()) {
            int i2 = i + 1;
            if (str.charAt(i) != '%') {
                i = i2;
            } else if (i2 < str.length()) {
                char cCharAt = str.charAt(i2);
                if (cCharAt != '%' && cCharAt != 'n') {
                    return i;
                }
                i += 2;
            } else {
                throw ParseException.withStartPosition("trailing unquoted '%' character", str, i);
            }
        }
        return -1;
    }

    private static int findFormatChar(String str, int i, int i2) {
        while (i2 < str.length()) {
            if (((char) ((str.charAt(i2) & (-33)) - 65)) < 26) {
                return i2;
            }
            i2++;
        }
        throw ParseException.withStartPosition("unterminated parameter", str, i);
    }

    static void unescapePrintf(StringBuilder sb, String str, int i, int i2) {
        int i3 = i;
        while (i < i2) {
            int i4 = i + 1;
            if (str.charAt(i) == '%') {
                if (i4 == i2) {
                    break;
                }
                char cCharAt = str.charAt(i4);
                if (cCharAt == '%') {
                    sb.append((CharSequence) str, i3, i4);
                } else if (cCharAt == 'n') {
                    sb.append((CharSequence) str, i3, i);
                    sb.append(SYSTEM_NEWLINE);
                }
                i3 = i + 2;
                i = i3;
            }
            i = i4;
        }
        if (i3 < i2) {
            sb.append((CharSequence) str, i3, i2);
        }
    }
}
