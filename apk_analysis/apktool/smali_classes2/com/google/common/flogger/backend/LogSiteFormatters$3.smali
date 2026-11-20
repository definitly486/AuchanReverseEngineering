.class final enum Lcom/google/common/flogger/backend/LogSiteFormatters$3;
.super Lcom/google/common/flogger/backend/LogSiteFormatters;
.source "LogSiteFormatters.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/backend/LogSiteFormatters;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4010
    name = null
.end annotation


# direct methods
.method constructor <init>(Ljava/lang/String;I)V
    .locals 1

    const/4 v0, 0x0

    .line 45
    invoke-direct {p0, p1, p2, v0}, Lcom/google/common/flogger/backend/LogSiteFormatters;-><init>(Ljava/lang/String;ILcom/google/common/flogger/backend/LogSiteFormatters$1;)V

    return-void
.end method


# virtual methods
.method public appendLogSite(Lcom/google/common/flogger/LogSite;Ljava/lang/StringBuilder;)Z
    .locals 5

    .line 55
    sget-object v0, Lcom/google/common/flogger/LogSite;->INVALID:Lcom/google/common/flogger/LogSite;

    if-ne p1, v0, :cond_0

    const/4 p1, 0x0

    return p1

    .line 58
    :cond_0
    invoke-virtual {p1}, Lcom/google/common/flogger/LogSite;->getClassName()Ljava/lang/String;

    move-result-object v0

    const/16 v1, 0x2e

    .line 59
    invoke-virtual {v0, v1}, Ljava/lang/String;->lastIndexOf(I)I

    move-result v2

    const/4 v3, -0x1

    const/4 v4, 0x1

    if-eq v2, v3, :cond_2

    add-int/2addr v2, v4

    .line 60
    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v3

    if-lt v2, v3, :cond_1

    goto :goto_0

    .line 63
    :cond_1
    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v3

    invoke-virtual {p2, v0, v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/CharSequence;II)Ljava/lang/StringBuilder;

    goto :goto_1

    .line 61
    :cond_2
    :goto_0
    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 65
    :goto_1
    invoke-virtual {p2, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Lcom/google/common/flogger/LogSite;->getMethodName()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v0, 0x3a

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {p1}, Lcom/google/common/flogger/LogSite;->getLineNumber()I

    move-result p1

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    return v4
.end method
