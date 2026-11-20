package com.google.common.flogger.parser;

import com.google.common.flogger.backend.FormatChar;
import com.google.common.flogger.backend.FormatOptions;
import com.google.common.flogger.parameter.DateTimeFormat;
import com.google.common.flogger.parameter.DateTimeParameter;
import com.google.common.flogger.parameter.Parameter;
import com.google.common.flogger.parameter.ParameterVisitor;
import com.google.common.flogger.parameter.SimpleParameter;
import org.tensorflow.lite.schema.BuiltinOperator;

/* JADX INFO: loaded from: classes2.dex */
public class DefaultPrintfMessageParser extends PrintfMessageParser {
    private static final PrintfMessageParser INSTANCE = new DefaultPrintfMessageParser();

    public static PrintfMessageParser getInstance() {
        return INSTANCE;
    }

    private DefaultPrintfMessageParser() {
    }

    @Override // com.google.common.flogger.parser.PrintfMessageParser
    public int parsePrintfTerm(MessageBuilder<?> messageBuilder, int i, String str, int i2, int i3, int i4) {
        Parameter parameterOf;
        int i5 = i4 + 1;
        char cCharAt = str.charAt(i4);
        FormatOptions formatOptions = FormatOptions.parse(str, i3, i4, (cCharAt & ' ') == 0);
        FormatChar formatCharOf = FormatChar.of(cCharAt);
        if (formatCharOf != null) {
            if (!formatOptions.areValidFor(formatCharOf)) {
                throw ParseException.withBounds("invalid format specifier", str, i2, i5);
            }
            parameterOf = SimpleParameter.of(i, formatCharOf, formatOptions);
        } else if (cCharAt == 't' || cCharAt == 'T') {
            if (!formatOptions.validate(BuiltinOperator.BITWISE_XOR, false)) {
                throw ParseException.withBounds("invalid format specification", str, i2, i5);
            }
            int i6 = i4 + 2;
            if (i6 > str.length()) {
                throw ParseException.atPosition("truncated format specifier", str, i2);
            }
            DateTimeFormat dateTimeFormatOf = DateTimeFormat.of(str.charAt(i5));
            if (dateTimeFormatOf == null) {
                throw ParseException.atPosition("illegal date/time conversion", str, i5);
            }
            parameterOf = DateTimeParameter.of(dateTimeFormatOf, formatOptions, i);
            i5 = i6;
        } else if (cCharAt == 'h' || cCharAt == 'H') {
            if (!formatOptions.validate(BuiltinOperator.BITWISE_XOR, false)) {
                throw ParseException.withBounds("invalid format specification", str, i2, i5);
            }
            parameterOf = wrapHexParameter(formatOptions, i);
        } else {
            throw ParseException.withBounds("invalid format specification", str, i2, i5);
        }
        messageBuilder.addParameter(i2, i5, parameterOf);
        return i5;
    }

    private static Parameter wrapHexParameter(final FormatOptions formatOptions, int i) {
        return new Parameter(formatOptions, i) { // from class: com.google.common.flogger.parser.DefaultPrintfMessageParser.1
            @Override // com.google.common.flogger.parameter.Parameter
            protected void accept(ParameterVisitor parameterVisitor, Object obj) {
                parameterVisitor.visit(Integer.valueOf(obj.hashCode()), FormatChar.HEX, getFormatOptions());
            }

            @Override // com.google.common.flogger.parameter.Parameter
            public String getFormat() {
                return formatOptions.shouldUpperCase() ? "%H" : "%h";
            }
        };
    }
}
