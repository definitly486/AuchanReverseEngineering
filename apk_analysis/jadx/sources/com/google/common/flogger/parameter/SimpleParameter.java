package com.google.common.flogger.parameter;

import com.google.common.flogger.backend.FormatChar;
import com.google.common.flogger.backend.FormatOptions;
import com.google.common.flogger.util.Checks;
import java.util.Collections;
import java.util.EnumMap;
import java.util.Map;

/* JADX INFO: loaded from: classes2.dex */
public final class SimpleParameter extends Parameter {
    private static final Map<FormatChar, SimpleParameter[]> DEFAULT_PARAMETERS;
    private static final int MAX_CACHED_PARAMETERS = 10;
    private final FormatChar formatChar;
    private final String formatString;

    static {
        EnumMap enumMap = new EnumMap(FormatChar.class);
        for (FormatChar formatChar : FormatChar.values()) {
            enumMap.put(formatChar, createParameterArray(formatChar));
        }
        DEFAULT_PARAMETERS = Collections.unmodifiableMap(enumMap);
    }

    private static SimpleParameter[] createParameterArray(FormatChar formatChar) {
        SimpleParameter[] simpleParameterArr = new SimpleParameter[10];
        for (int i = 0; i < 10; i++) {
            simpleParameterArr[i] = new SimpleParameter(i, formatChar, FormatOptions.getDefault());
        }
        return simpleParameterArr;
    }

    public static SimpleParameter of(int i, FormatChar formatChar, FormatOptions formatOptions) {
        if (i < 10 && formatOptions.isDefault()) {
            return ((SimpleParameter[]) Checks.checkNotNull(DEFAULT_PARAMETERS.get(formatChar), "default parameter"))[i];
        }
        return new SimpleParameter(i, formatChar, formatOptions);
    }

    private SimpleParameter(int i, FormatChar formatChar, FormatOptions formatOptions) {
        String strBuildFormatString;
        super(formatOptions, i);
        this.formatChar = (FormatChar) Checks.checkNotNull(formatChar, "format char");
        if (formatOptions.isDefault()) {
            strBuildFormatString = formatChar.getDefaultFormatString();
        } else {
            strBuildFormatString = buildFormatString(formatOptions, formatChar);
        }
        this.formatString = strBuildFormatString;
    }

    static String buildFormatString(FormatOptions formatOptions, FormatChar formatChar) {
        char c = formatChar.getChar();
        if (formatOptions.shouldUpperCase()) {
            c = (char) (c & (-33));
        }
        StringBuilder sbAppendPrintfOptions = formatOptions.appendPrintfOptions(new StringBuilder("%"));
        sbAppendPrintfOptions.append(c);
        return sbAppendPrintfOptions.toString();
    }

    @Override // com.google.common.flogger.parameter.Parameter
    protected void accept(ParameterVisitor parameterVisitor, Object obj) {
        parameterVisitor.visit(obj, this.formatChar, getFormatOptions());
    }

    @Override // com.google.common.flogger.parameter.Parameter
    public String getFormat() {
        return this.formatString;
    }
}
