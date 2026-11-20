.class public Lcom/google/common/flogger/backend/BaseMessageFormatter;
.super Lcom/google/common/flogger/parser/MessageBuilder;
.source "BaseMessageFormatter.java"

# interfaces
.implements Lcom/google/common/flogger/parameter/ParameterVisitor;


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/common/flogger/parser/MessageBuilder<",
        "Ljava/lang/StringBuilder;",
        ">;",
        "Lcom/google/common/flogger/parameter/ParameterVisitor;"
    }
.end annotation


# static fields
.field private static final EXTRA_ARGUMENT_MESSAGE:Ljava/lang/String; = " [ERROR: UNUSED LOG ARGUMENTS]"

.field private static final MISSING_ARGUMENT_MESSAGE:Ljava/lang/String; = "[ERROR: MISSING LOG ARGUMENT]"


# instance fields
.field protected final args:[Ljava/lang/Object;

.field private literalStart:I

.field protected final out:Ljava/lang/StringBuilder;


# direct methods
.method protected constructor <init>(Lcom/google/common/flogger/backend/TemplateContext;[Ljava/lang/Object;Ljava/lang/StringBuilder;)V
    .locals 0

    .line 81
    invoke-direct {p0, p1}, Lcom/google/common/flogger/parser/MessageBuilder;-><init>(Lcom/google/common/flogger/backend/TemplateContext;)V

    const/4 p1, 0x0

    .line 78
    iput p1, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->literalStart:I

    .line 82
    const-string p1, "arguments"

    invoke-static {p2, p1}, Lcom/google/common/flogger/util/Checks;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, [Ljava/lang/Object;

    iput-object p1, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->args:[Ljava/lang/Object;

    .line 83
    const-string p1, "buffer"

    invoke-static {p3, p1}, Lcom/google/common/flogger/util/Checks;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/StringBuilder;

    iput-object p1, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    return-void
.end method

.method private static appendFormatted(Ljava/lang/StringBuilder;Ljava/lang/Object;Lcom/google/common/flogger/backend/FormatChar;Lcom/google/common/flogger/backend/FormatOptions;)V
    .locals 2

    .line 102
    sget-object v0, Lcom/google/common/flogger/backend/BaseMessageFormatter$1;->$SwitchMap$com$google$common$flogger$backend$FormatChar:[I

    invoke-virtual {p2}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    const/4 v1, 0x1

    if-eq v0, v1, :cond_5

    const/4 v1, 0x2

    if-eq v0, v1, :cond_4

    const/4 v1, 0x3

    if-eq v0, v1, :cond_4

    const/4 v1, 0x4

    if-eq v0, v1, :cond_3

    const/4 v1, 0x5

    if-eq v0, v1, :cond_0

    goto :goto_0

    .line 139
    :cond_0
    invoke-virtual {p3}, Lcom/google/common/flogger/backend/FormatOptions;->isDefault()Z

    move-result v0

    if-eqz v0, :cond_6

    .line 140
    instance-of p2, p1, Ljava/lang/Character;

    if-eqz p2, :cond_1

    .line 141
    invoke-virtual {p0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    return-void

    .line 145
    :cond_1
    check-cast p1, Ljava/lang/Number;

    invoke-virtual {p1}, Ljava/lang/Number;->intValue()I

    move-result p1

    ushr-int/lit8 p2, p1, 0x10

    if-nez p2, :cond_2

    int-to-char p1, p1

    .line 147
    invoke-virtual {p0, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    return-void

    .line 150
    :cond_2
    invoke-static {p1}, Ljava/lang/Character;->toChars(I)[C

    move-result-object p1

    invoke-virtual {p0, p1}, Ljava/lang/StringBuilder;->append([C)Ljava/lang/StringBuilder;

    return-void

    :cond_3
    const/16 v0, 0x80

    const/4 v1, 0x0

    .line 129
    invoke-virtual {p3, v0, v1, v1}, Lcom/google/common/flogger/backend/FormatOptions;->filter(IZZ)Lcom/google/common/flogger/backend/FormatOptions;

    move-result-object v0

    invoke-virtual {v0, p3}, Lcom/google/common/flogger/backend/FormatOptions;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_6

    .line 131
    check-cast p1, Ljava/lang/Number;

    invoke-static {p0, p1, p3}, Lcom/google/common/flogger/backend/MessageUtils;->appendHex(Ljava/lang/StringBuilder;Ljava/lang/Number;Lcom/google/common/flogger/backend/FormatOptions;)V

    return-void

    .line 120
    :cond_4
    invoke-virtual {p3}, Lcom/google/common/flogger/backend/FormatOptions;->isDefault()Z

    move-result v0

    if-eqz v0, :cond_6

    .line 121
    invoke-virtual {p0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    return-void

    .line 105
    :cond_5
    instance-of v0, p1, Ljava/util/Formattable;

    if-nez v0, :cond_9

    .line 106
    invoke-virtual {p3}, Lcom/google/common/flogger/backend/FormatOptions;->isDefault()Z

    move-result v0

    if-eqz v0, :cond_6

    .line 108
    invoke-static {p1}, Lcom/google/common/flogger/backend/MessageUtils;->safeToString(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void

    .line 159
    :cond_6
    :goto_0
    invoke-virtual {p2}, Lcom/google/common/flogger/backend/FormatChar;->getDefaultFormatString()Ljava/lang/String;

    move-result-object v0

    .line 160
    invoke-virtual {p3}, Lcom/google/common/flogger/backend/FormatOptions;->isDefault()Z

    move-result v1

    if-nez v1, :cond_8

    .line 161
    invoke-virtual {p2}, Lcom/google/common/flogger/backend/FormatChar;->getChar()C

    move-result p2

    .line 162
    invoke-virtual {p3}, Lcom/google/common/flogger/backend/FormatOptions;->shouldUpperCase()Z

    move-result v0

    if-eqz v0, :cond_7

    const v0, 0xffdf

    and-int/2addr p2, v0

    int-to-char p2, p2

    .line 166
    :cond_7
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "%"

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    invoke-virtual {p3, v0}, Lcom/google/common/flogger/backend/FormatOptions;->appendPrintfOptions(Ljava/lang/StringBuilder;)Ljava/lang/StringBuilder;

    move-result-object p3

    invoke-virtual {p3, p2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {p3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 168
    :cond_8
    sget-object p2, Lcom/google/common/flogger/backend/MessageUtils;->FORMAT_LOCALE:Ljava/util/Locale;

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    invoke-static {p2, v0, p1}, Ljava/lang/String;->format(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void

    .line 114
    :cond_9
    check-cast p1, Ljava/util/Formattable;

    invoke-static {p1, p0, p3}, Lcom/google/common/flogger/backend/MessageUtils;->safeFormatTo(Ljava/util/Formattable;Ljava/lang/StringBuilder;Lcom/google/common/flogger/backend/FormatOptions;)V

    return-void
.end method

.method public static appendFormattedMessage(Lcom/google/common/flogger/backend/LogData;Ljava/lang/StringBuilder;)Ljava/lang/StringBuilder;
    .locals 3
    .annotation build Lcom/google/errorprone/annotations/CanIgnoreReturnValue;
    .end annotation

    .line 59
    invoke-interface {p0}, Lcom/google/common/flogger/backend/LogData;->getTemplateContext()Lcom/google/common/flogger/backend/TemplateContext;

    move-result-object v0

    if-eqz v0, :cond_1

    .line 60
    new-instance v0, Lcom/google/common/flogger/backend/BaseMessageFormatter;

    .line 61
    invoke-interface {p0}, Lcom/google/common/flogger/backend/LogData;->getTemplateContext()Lcom/google/common/flogger/backend/TemplateContext;

    move-result-object v1

    invoke-interface {p0}, Lcom/google/common/flogger/backend/LogData;->getArguments()[Ljava/lang/Object;

    move-result-object v2

    invoke-direct {v0, v1, v2, p1}, Lcom/google/common/flogger/backend/BaseMessageFormatter;-><init>(Lcom/google/common/flogger/backend/TemplateContext;[Ljava/lang/Object;Ljava/lang/StringBuilder;)V

    .line 62
    invoke-virtual {v0}, Lcom/google/common/flogger/parser/MessageBuilder;->build()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/StringBuilder;

    .line 63
    invoke-interface {p0}, Lcom/google/common/flogger/backend/LogData;->getArguments()[Ljava/lang/Object;

    move-result-object p0

    array-length p0, p0

    invoke-virtual {v0}, Lcom/google/common/flogger/parser/MessageBuilder;->getExpectedArgumentCount()I

    move-result v0

    if-le p0, v0, :cond_0

    .line 65
    const-string p0, " [ERROR: UNUSED LOG ARGUMENTS]"

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    :cond_0
    return-object p1

    .line 68
    :cond_1
    invoke-interface {p0}, Lcom/google/common/flogger/backend/LogData;->getLiteralArgument()Ljava/lang/Object;

    move-result-object p0

    invoke-static {p0}, Lcom/google/common/flogger/backend/MessageUtils;->safeToString(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p0

    invoke-virtual {p1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-object p1
.end method

.method private static appendInvalid(Ljava/lang/StringBuilder;Ljava/lang/Object;Ljava/lang/String;)V
    .locals 1

    .line 225
    const-string v0, "[INVALID: format="

    invoke-virtual {p0, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 226
    invoke-virtual {p0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p2, ", type="

    .line 227
    invoke-virtual {p0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 228
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p2

    invoke-virtual {p2}, Ljava/lang/Class;->getCanonicalName()Ljava/lang/String;

    move-result-object p2

    invoke-virtual {p0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p2, ", value="

    .line 229
    invoke-virtual {p0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 230
    invoke-static {p1}, Lcom/google/common/flogger/backend/MessageUtils;->safeToString(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, "]"

    .line 231
    invoke-virtual {p0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void
.end method


# virtual methods
.method public addParameterImpl(IILcom/google/common/flogger/parameter/Parameter;)V
    .locals 4

    .line 173
    invoke-virtual {p0}, Lcom/google/common/flogger/parser/MessageBuilder;->getParser()Lcom/google/common/flogger/parser/MessageParser;

    move-result-object v0

    iget-object v1, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    invoke-virtual {p0}, Lcom/google/common/flogger/parser/MessageBuilder;->getMessage()Ljava/lang/String;

    move-result-object v2

    iget v3, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->literalStart:I

    invoke-virtual {v0, v1, v2, v3, p1}, Lcom/google/common/flogger/parser/MessageParser;->unescape(Ljava/lang/StringBuilder;Ljava/lang/String;II)V

    .line 174
    iget-object p1, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->args:[Ljava/lang/Object;

    invoke-virtual {p3, p0, p1}, Lcom/google/common/flogger/parameter/Parameter;->accept(Lcom/google/common/flogger/parameter/ParameterVisitor;[Ljava/lang/Object;)V

    .line 175
    iput p2, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->literalStart:I

    return-void
.end method

.method public bridge synthetic buildImpl()Ljava/lang/Object;
    .locals 1

    .line 38
    invoke-virtual {p0}, Lcom/google/common/flogger/backend/BaseMessageFormatter;->buildImpl()Ljava/lang/StringBuilder;

    move-result-object v0

    return-object v0
.end method

.method public buildImpl()Ljava/lang/StringBuilder;
    .locals 5

    .line 180
    invoke-virtual {p0}, Lcom/google/common/flogger/parser/MessageBuilder;->getParser()Lcom/google/common/flogger/parser/MessageParser;

    move-result-object v0

    iget-object v1, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    invoke-virtual {p0}, Lcom/google/common/flogger/parser/MessageBuilder;->getMessage()Ljava/lang/String;

    move-result-object v2

    iget v3, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->literalStart:I

    invoke-virtual {p0}, Lcom/google/common/flogger/parser/MessageBuilder;->getMessage()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/String;->length()I

    move-result v4

    invoke-virtual {v0, v1, v2, v3, v4}, Lcom/google/common/flogger/parser/MessageParser;->unescape(Ljava/lang/StringBuilder;Ljava/lang/String;II)V

    .line 181
    iget-object v0, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    return-object v0
.end method

.method public visit(Ljava/lang/Object;Lcom/google/common/flogger/backend/FormatChar;Lcom/google/common/flogger/backend/FormatOptions;)V
    .locals 1

    .line 186
    invoke-virtual {p2}, Lcom/google/common/flogger/backend/FormatChar;->getType()Lcom/google/common/flogger/backend/FormatType;

    move-result-object v0

    invoke-virtual {v0, p1}, Lcom/google/common/flogger/backend/FormatType;->canFormat(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 187
    iget-object v0, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    invoke-static {v0, p1, p2, p3}, Lcom/google/common/flogger/backend/BaseMessageFormatter;->appendFormatted(Ljava/lang/StringBuilder;Ljava/lang/Object;Lcom/google/common/flogger/backend/FormatChar;Lcom/google/common/flogger/backend/FormatOptions;)V

    return-void

    .line 189
    :cond_0
    iget-object p3, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Lcom/google/common/flogger/backend/FormatChar;->getDefaultFormatString()Ljava/lang/String;

    move-result-object p2

    invoke-static {p3, p1, p2}, Lcom/google/common/flogger/backend/BaseMessageFormatter;->appendInvalid(Ljava/lang/StringBuilder;Ljava/lang/Object;Ljava/lang/String;)V

    return-void
.end method

.method public visitDateTime(Ljava/lang/Object;Lcom/google/common/flogger/parameter/DateTimeFormat;Lcom/google/common/flogger/backend/FormatOptions;)V
    .locals 2

    .line 195
    instance-of v0, p1, Ljava/util/Date;

    if-nez v0, :cond_1

    instance-of v0, p1, Ljava/util/Calendar;

    if-nez v0, :cond_1

    instance-of v0, p1, Ljava/lang/Long;

    if-eqz v0, :cond_0

    goto :goto_0

    .line 204
    :cond_0
    iget-object p3, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "%t"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Lcom/google/common/flogger/parameter/DateTimeFormat;->getChar()C

    move-result p2

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-static {p3, p1, p2}, Lcom/google/common/flogger/backend/BaseMessageFormatter;->appendInvalid(Ljava/lang/StringBuilder;Ljava/lang/Object;Ljava/lang/String;)V

    return-void

    .line 196
    :cond_1
    :goto_0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "%"

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 198
    invoke-virtual {p3, v0}, Lcom/google/common/flogger/backend/FormatOptions;->appendPrintfOptions(Ljava/lang/StringBuilder;)Ljava/lang/StringBuilder;

    move-result-object v0

    .line 199
    invoke-virtual {p3}, Lcom/google/common/flogger/backend/FormatOptions;->shouldUpperCase()Z

    move-result p3

    if-eqz p3, :cond_2

    const/16 p3, 0x54

    goto :goto_1

    :cond_2
    const/16 p3, 0x74

    :goto_1
    invoke-virtual {v0, p3}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 200
    invoke-virtual {p2}, Lcom/google/common/flogger/parameter/DateTimeFormat;->getChar()C

    move-result p2

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    .line 201
    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    .line 202
    iget-object p3, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    sget-object v0, Lcom/google/common/flogger/backend/MessageUtils;->FORMAT_LOCALE:Ljava/util/Locale;

    filled-new-array {p1}, [Ljava/lang/Object;

    move-result-object p1

    invoke-static {v0, p2, p1}, Ljava/lang/String;->format(Ljava/util/Locale;Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p3, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void
.end method

.method public visitMissing()V
    .locals 2

    .line 216
    iget-object v0, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    const-string v1, "[ERROR: MISSING LOG ARGUMENT]"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void
.end method

.method public visitNull()V
    .locals 2

    .line 221
    iget-object v0, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    const-string v1, "null"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void
.end method

.method public visitPreformatted(Ljava/lang/Object;Ljava/lang/String;)V
    .locals 0

    .line 211
    iget-object p1, p0, Lcom/google/common/flogger/backend/BaseMessageFormatter;->out:Ljava/lang/StringBuilder;

    invoke-virtual {p1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void
.end method
