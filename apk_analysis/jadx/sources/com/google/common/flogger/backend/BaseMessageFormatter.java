package com.google.common.flogger.backend;

import com.google.common.flogger.parameter.DateTimeFormat;
import com.google.common.flogger.parameter.Parameter;
import com.google.common.flogger.parameter.ParameterVisitor;
import com.google.common.flogger.parser.MessageBuilder;
import com.google.common.flogger.util.Checks;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.util.Calendar;
import java.util.Date;
import java.util.Formattable;

/* JADX INFO: loaded from: classes2.dex */
public class BaseMessageFormatter extends MessageBuilder<StringBuilder> implements ParameterVisitor {
    private static final String EXTRA_ARGUMENT_MESSAGE = " [ERROR: UNUSED LOG ARGUMENTS]";
    private static final String MISSING_ARGUMENT_MESSAGE = "[ERROR: MISSING LOG ARGUMENT]";
    protected final Object[] args;
    private int literalStart;
    protected final StringBuilder out;

    @CanIgnoreReturnValue
    public static StringBuilder appendFormattedMessage(LogData logData, StringBuilder sb) {
        if (logData.getTemplateContext() != null) {
            BaseMessageFormatter baseMessageFormatter = new BaseMessageFormatter(logData.getTemplateContext(), logData.getArguments(), sb);
            StringBuilder sbBuild = baseMessageFormatter.build();
            if (logData.getArguments().length > baseMessageFormatter.getExpectedArgumentCount()) {
                sbBuild.append(EXTRA_ARGUMENT_MESSAGE);
            }
            return sbBuild;
        }
        sb.append(MessageUtils.safeToString(logData.getLiteralArgument()));
        return sb;
    }

    protected BaseMessageFormatter(TemplateContext templateContext, Object[] objArr, StringBuilder sb) {
        super(templateContext);
        this.literalStart = 0;
        this.args = (Object[]) Checks.checkNotNull(objArr, "arguments");
        this.out = (StringBuilder) Checks.checkNotNull(sb, "buffer");
    }

    /* JADX INFO: renamed from: com.google.common.flogger.backend.BaseMessageFormatter$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$com$google$common$flogger$backend$FormatChar;

        static {
            int[] iArr = new int[FormatChar.values().length];
            $SwitchMap$com$google$common$flogger$backend$FormatChar = iArr;
            try {
                iArr[FormatChar.STRING.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$com$google$common$flogger$backend$FormatChar[FormatChar.DECIMAL.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$com$google$common$flogger$backend$FormatChar[FormatChar.BOOLEAN.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$com$google$common$flogger$backend$FormatChar[FormatChar.HEX.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                $SwitchMap$com$google$common$flogger$backend$FormatChar[FormatChar.CHAR.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
        }
    }

    private static void appendFormatted(StringBuilder sb, Object obj, FormatChar formatChar, FormatOptions formatOptions) {
        int i = AnonymousClass1.$SwitchMap$com$google$common$flogger$backend$FormatChar[formatChar.ordinal()];
        if (i != 1) {
            if (i == 2 || i == 3) {
                if (formatOptions.isDefault()) {
                    sb.append(obj);
                    return;
                }
            } else if (i == 4) {
                if (formatOptions.filter(128, false, false).equals(formatOptions)) {
                    MessageUtils.appendHex(sb, (Number) obj, formatOptions);
                    return;
                }
            } else if (i == 5 && formatOptions.isDefault()) {
                if (obj instanceof Character) {
                    sb.append(obj);
                    return;
                }
                int iIntValue = ((Number) obj).intValue();
                if ((iIntValue >>> 16) == 0) {
                    sb.append((char) iIntValue);
                    return;
                } else {
                    sb.append(Character.toChars(iIntValue));
                    return;
                }
            }
        } else if (!(obj instanceof Formattable)) {
            if (formatOptions.isDefault()) {
                sb.append(MessageUtils.safeToString(obj));
                return;
            }
        } else {
            MessageUtils.safeFormatTo((Formattable) obj, sb, formatOptions);
            return;
        }
        String defaultFormatString = formatChar.getDefaultFormatString();
        if (!formatOptions.isDefault()) {
            char c = formatChar.getChar();
            if (formatOptions.shouldUpperCase()) {
                c = (char) (c & 65503);
            }
            StringBuilder sbAppendPrintfOptions = formatOptions.appendPrintfOptions(new StringBuilder("%"));
            sbAppendPrintfOptions.append(c);
            defaultFormatString = sbAppendPrintfOptions.toString();
        }
        sb.append(String.format(MessageUtils.FORMAT_LOCALE, defaultFormatString, obj));
    }

    @Override // com.google.common.flogger.parser.MessageBuilder
    public void addParameterImpl(int i, int i2, Parameter parameter) {
        getParser().unescape(this.out, getMessage(), this.literalStart, i);
        parameter.accept((ParameterVisitor) this, this.args);
        this.literalStart = i2;
    }

    @Override // com.google.common.flogger.parser.MessageBuilder
    public StringBuilder buildImpl() {
        getParser().unescape(this.out, getMessage(), this.literalStart, getMessage().length());
        return this.out;
    }

    @Override // com.google.common.flogger.parameter.ParameterVisitor
    public void visit(Object obj, FormatChar formatChar, FormatOptions formatOptions) {
        if (formatChar.getType().canFormat(obj)) {
            appendFormatted(this.out, obj, formatChar, formatOptions);
        } else {
            appendInvalid(this.out, obj, formatChar.getDefaultFormatString());
        }
    }

    @Override // com.google.common.flogger.parameter.ParameterVisitor
    public void visitDateTime(Object obj, DateTimeFormat dateTimeFormat, FormatOptions formatOptions) {
        if ((obj instanceof Date) || (obj instanceof Calendar) || (obj instanceof Long)) {
            StringBuilder sbAppendPrintfOptions = formatOptions.appendPrintfOptions(new StringBuilder("%"));
            sbAppendPrintfOptions.append(formatOptions.shouldUpperCase() ? 'T' : 't');
            sbAppendPrintfOptions.append(dateTimeFormat.getChar());
            this.out.append(String.format(MessageUtils.FORMAT_LOCALE, sbAppendPrintfOptions.toString(), obj));
            return;
        }
        appendInvalid(this.out, obj, "%t" + dateTimeFormat.getChar());
    }

    @Override // com.google.common.flogger.parameter.ParameterVisitor
    public void visitPreformatted(Object obj, String str) {
        this.out.append(str);
    }

    @Override // com.google.common.flogger.parameter.ParameterVisitor
    public void visitMissing() {
        this.out.append(MISSING_ARGUMENT_MESSAGE);
    }

    @Override // com.google.common.flogger.parameter.ParameterVisitor
    public void visitNull() {
        this.out.append("null");
    }

    private static void appendInvalid(StringBuilder sb, Object obj, String str) {
        sb.append("[INVALID: format=");
        sb.append(str);
        sb.append(", type=");
        sb.append(obj.getClass().getCanonicalName());
        sb.append(", value=");
        sb.append(MessageUtils.safeToString(obj));
        sb.append("]");
    }
}
