.class final Lcom/google/common/flogger/LogSite$InjectedLogSite;
.super Lcom/google/common/flogger/LogSite;
.source "LogSite.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/LogSite;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "InjectedLogSite"
.end annotation


# instance fields
.field private final encodedLineNumber:I

.field private hashcode:I

.field private final internalClassName:Ljava/lang/String;

.field private final methodName:Ljava/lang/String;

.field private final sourceFilePath:Ljava/lang/String;


# direct methods
.method private constructor <init>(Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;)V
    .locals 1

    .line 164
    invoke-direct {p0}, Lcom/google/common/flogger/LogSite;-><init>()V

    const/4 v0, 0x0

    .line 158
    iput v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->hashcode:I

    .line 165
    const-string v0, "class name"

    invoke-static {p1, v0}, Lcom/google/common/flogger/util/Checks;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    iput-object p1, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->internalClassName:Ljava/lang/String;

    .line 166
    const-string p1, "method name"

    invoke-static {p2, p1}, Lcom/google/common/flogger/util/Checks;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Ljava/lang/String;

    iput-object p1, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->methodName:Ljava/lang/String;

    .line 167
    iput p3, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->encodedLineNumber:I

    .line 168
    iput-object p4, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->sourceFilePath:Ljava/lang/String;

    return-void
.end method

.method synthetic constructor <init>(Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;Lcom/google/common/flogger/LogSite$1;)V
    .locals 0

    .line 149
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/google/common/flogger/LogSite$InjectedLogSite;-><init>(Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;)V

    return-void
.end method

.method private static internalNamesCompatible(Ljava/lang/String;Ljava/lang/String;)Z
    .locals 7

    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    .line 225
    :cond_0
    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v1

    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v2

    const/4 v3, 0x0

    if-eq v1, v2, :cond_1

    return v3

    :cond_1
    move v1, v3

    .line 229
    :goto_0
    invoke-virtual {p0}, Ljava/lang/String;->length()I

    move-result v2

    if-ge v1, v2, :cond_4

    .line 230
    invoke-virtual {p0, v1}, Ljava/lang/String;->charAt(I)C

    move-result v2

    .line 231
    invoke-virtual {p1, v1}, Ljava/lang/String;->charAt(I)C

    move-result v4

    if-eq v2, v4, :cond_3

    and-int/lit8 v5, v2, -0x2

    const/16 v6, 0x2e

    if-ne v5, v6, :cond_2

    xor-int/2addr v2, v4

    if-eq v2, v0, :cond_3

    :cond_2
    return v3

    :cond_3
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_4
    return v0
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 3

    .line 205
    instance-of v0, p1, Lcom/google/common/flogger/LogSite$InjectedLogSite;

    const/4 v1, 0x0

    if-eqz v0, :cond_0

    .line 206
    check-cast p1, Lcom/google/common/flogger/LogSite$InjectedLogSite;

    .line 208
    iget-object v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->methodName:Ljava/lang/String;

    iget-object v2, p1, Lcom/google/common/flogger/LogSite$InjectedLogSite;->methodName:Ljava/lang/String;

    invoke-virtual {v0, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->encodedLineNumber:I

    iget v2, p1, Lcom/google/common/flogger/LogSite$InjectedLogSite;->encodedLineNumber:I

    if-ne v0, v2, :cond_0

    iget-object v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->internalClassName:Ljava/lang/String;

    iget-object p1, p1, Lcom/google/common/flogger/LogSite$InjectedLogSite;->internalClassName:Ljava/lang/String;

    .line 211
    invoke-static {v0, p1}, Lcom/google/common/flogger/LogSite$InjectedLogSite;->internalNamesCompatible(Ljava/lang/String;Ljava/lang/String;)Z

    move-result p1

    if-eqz p1, :cond_0

    const/4 p1, 0x1

    return p1

    :cond_0
    return v1
.end method

.method public getClassName()Ljava/lang/String;
    .locals 3

    .line 180
    iget-object v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->internalClassName:Ljava/lang/String;

    const/16 v1, 0x2f

    const/16 v2, 0x2e

    invoke-virtual {v0, v1, v2}, Ljava/lang/String;->replace(CC)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getFileName()Ljava/lang/String;
    .locals 2

    .line 197
    iget-object v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->sourceFilePath:Ljava/lang/String;

    if-nez v0, :cond_0

    const/4 v0, 0x0

    return-object v0

    .line 200
    :cond_0
    sget-char v1, Ljava/io/File;->separatorChar:C

    invoke-virtual {v0, v1}, Ljava/lang/String;->lastIndexOf(I)I

    move-result v1

    add-int/lit8 v1, v1, 0x1

    invoke-virtual {v0, v1}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public getLineNumber()I
    .locals 2

    .line 191
    iget v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->encodedLineNumber:I

    const v1, 0xffff

    and-int/2addr v0, v1

    return v0
.end method

.method public getMethodName()Ljava/lang/String;
    .locals 1

    .line 185
    iget-object v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->methodName:Ljava/lang/String;

    return-object v0
.end method

.method public hashCode()I
    .locals 2

    .line 245
    iget v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->hashcode:I

    if-nez v0, :cond_0

    .line 252
    iget-object v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->methodName:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    const/16 v1, 0x1303

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    .line 253
    iget v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->encodedLineNumber:I

    add-int/2addr v1, v0

    .line 254
    iput v1, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->hashcode:I

    .line 256
    :cond_0
    iget v0, p0, Lcom/google/common/flogger/LogSite$InjectedLogSite;->hashcode:I

    return v0
.end method
